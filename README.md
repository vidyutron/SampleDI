
# DI and Injection
## Principles and design pattern

Here we will learn the principles(in-action) and motivation behind the dependency inversion and injection. 


# Architecture

![Alt text](/_img/proj_struct_01.png?raw=true "Optional Title")
# 
Things which makes organization and future extension better: 
1. Create a folder and namespaces in a project to organize similar and linked classes and their interfaces together.
2. There is no set restriction of following only n-tier folder and namespace design, if you believe the structuring of projects/folders/namespaces are better based on functionality, please go ahead with that way of organization.
3. Make a habit of segregating the projects based on the high-level responsibilities like Data Access, Domain Functionalities, business logic at a high level.
4. Create an interface for the classes(functionality group) which you think will be used by a lot of other classes (DEPENDENCY INVERSION)
5. Use reflection for automation of mapping properties, loading classes in bulk, creating factory instances, etc, **Point 1**, will greatly help in achieving this.
6. Follow One class - One file rule.
7. Write less code per file.


# What is dependency inversion?
High-level modules should not depend on low-level modules; both should depend on abstractions. 
Abstractions should not depend on details. 
Details should depend upon abstractions

> _** Associate a class with an interface and use the interface for injection, external reference and writing the guidelines of a class using the method statement.**_ 

Though when you are starting with this way of writing code, it might appear to be a counter-intuitive that why we are creating an additional set of files that don't have much, except some single-line statements. 
But, we will see that as we build any loosely coupled system(jargon!) how evident it becomes that we interact with skeleton and not the concrete full body of the code.

# What is dependency Injection?
It allows the creation of dependent objects outside of a class and provides those objects to a class through various ways like constructor injection(recommended), method injection or property injection.

> Make objects available to other classes though some means of parameterized argument or property passing, without explicitly sending.

Whhaaat! passing something but without sending them?? Please hold your horses for the time being. We will understand how

# What is a factory pattern?
> Well many of them know by the virtue of its name itself, so no explanation but we will see how using **Autofac** we achieve this and help ourselves in the quest for injecting dependencies.


# Now, some real stuff!

**What's Happening?**  

![Alt text](/_img/graph_01.PNG?raw=true "Optional Title")  


**Class**: Bootstrap.cs  
**Library Used**: Autofac  
**Funtionality**: Configure the dependency injection by :   
A. Registering the types(class) which would be used in the pipeline( with reference from above illustration ).  
B. Resolving the registered classes using Autofac, which basically is behind the scene factory object creation with the parameterized constructors.  

    public static class Bootstrap
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Startup>();
            builder.RegisterType<Config>().As<IConfig>();
            builder.RegisterType<Util>().As<IUtil>();
            builder.RegisterType<Operations>().As<IOperations>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DomainLayer)))
                .Where(t => t.Namespace.Contains("Fork"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
Above, we register the types(participating classes) using *.RegisterType<>* or better if we organize our project in such a way that whole projects could be loaded at once using the *.RegisterAssemblyTypes<>*, above we have structured the classes and their abstraction with a proper naming convention such that we use the power of **Reflection** and **Linq** to get all the mapping in a single shot.

  
    
    
**Class**: Startup.cs  
**Library Used**: Windows.Forms
**Functionality**: Wrapper to inject items and call win form entry form.
public class Startup
    {
        private IUtil _util;
        private IConfig _config;

        public Startup(IUtil util,IConfig config)
        {
            _util = util;
            _config = config;
        }

        public void Run()
        {
            var form = new Form1(_util,_config);
            Application.Run(form);
        }
    }  

**Class**: Program.cs  
**Library Used**: Autofac
**Funtionality**: MAIN ENTRY POINT of our application, because it's *static void main!*

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootstrap = Bootstrap.Configure();
            using(var scope = bootstrap.BeginLifetimeScope())
            {
                var startup = scope.Resolve<Startup>();
                startup.Run();
            }
        }

Here connect the configuration done in bootstrap class to the startup class with the **.Resolve<>** extension. **.Run()** simply starts the form1.  
.Resolve is the key, this internally translates into the creation of objects for all the registered classes mentioned in the Bootstrap.Configure( ), such that all constructor injection happens behind the scene and no *object newing* explicitly.  

Example :   
![Alt text](/_img/cons_injection_01.png?raw=true "Optional Title")

Here, if you see the reference to the constructor is 0, yet util IConfig and operation gets injected into the constructor and could be used by rest of the Util.cs's functionality. This magic is possible because of internal factory object creation and injection using **AutoFac**.  

If you browse several of the concrete classes you will find similar pattern of important dependencies( in our example we are using only important ones!) being passed through the constructor, this greatly makes the de-coupling better and efficient scoping of the objects, instead of simply making everything static or global and cluttering the scope and memory.
**Most Importantly - if you look closely we are hardly doing new object(), and this is key to the Dependency Inversion** 
 
 



