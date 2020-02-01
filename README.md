
# DI and Injection
## Principles and design pattern

Here we will learn the principles(in action) and motivation behind the dependency inversion and injection. 


# Architecture

![Alt text](/_img/proj_struct_01.png?raw=true "Optional Title")
# 
Things which makes organisation and future extension better: 
1. Create folder and namespaces in project to organise similar and linked classes and their interfaces together.
2. There is no set restrition of following only n-tier folder and namespace design, if you believe the structuring of projects/folders/namespaces are better based on functionality, please go ahead with that way of organisation.
3. Make a habit of segregating the projects based on the high level responsibilities like Data Access, Domain Functionalities, business logic at high level.
4. Create interface for the classes(functionality group) which you think will be used by lot of other classes (DEPENDENCY INVERSION)
5. Use reflection for automation of mapping properties, loading classes in bulk, creating factory instances etc, **Point 1**, will greatly helps in achieving this.
6. Follow One class - One file rule.
7. Write less code per file.


# What is dependency inversion?
High level modules should not depend on low level modules; both should depend on abstractions. 
Abstractions should not depend on details. 
Details should depend upon abstractions

> _** Associate a class with an interface and use the interface for injection, external reference and writing the guidelines of a class using the method statement.**_ 

Though when you are starting with this way of writing code, it might appear to be a counter intuitive that why we are creating an additional set of files which doesn't have much except some single line statements. 
But, we will see that as we build any loosely coupled system(jargon!) how evident it becomes that we interact with skeleton and not the concrete full body of the code.

# What is dependency Injection?
It allows the creation of dependent objects outside of a class and provides those objects to a class through various ways like constructor injection(recommended), method injection or property injection.

> Make objects available to other classes though some means of paramerised argument or property passing, without explicitly sending them( whhaaat!, I am passing something but not actually sending them??)

Please hold your horses for the time being.

# What is factory pattern?
> Well many of them know by the virtue of the its name itself, so no explanation but we will see how using **Autofac** we achieve this and help ourselves in the quest for injecting dependecies.


# Now, some real stuff!

**What's Happening?**  
![Alt text](/_img/grah_01.png?raw=true "Optional Title")  


**Class**: Bootstrap.cs  
**Library Used**: Autofac  
**Funtionality**: Configure the dependency injection by :   
A. Registering the types(class) which would be used in the pipeline( with reference from above illustration ).  
B. Resolving the registered classes using Autfac, which basically is behind the scene factory object creation with the prameterized constructors.  

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
Above, we register the types(participating classes) using *.RegisterType<>* or better if we organise our project in such way that whole projects could loaded at once using the *.RegisterAssemblyTypes<>*, above we have structured the classes and their abstraction with proper naming convention such that we use the power of **Reflection** and **Linq** to get all the mapping in single shot.

  
    
    
**Class**: Startup.cs  
**Library Used**: Windows.Forms  
**Funtionality**: Wrapper to inject items and call win form entry form.
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
**Funtionality**: MAIN ENTRY POINT of our application, because it is *static void main*

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

 




