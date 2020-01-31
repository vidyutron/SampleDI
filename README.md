# SampleDI
Learn the principles(in action) and motivation behind the dependency inversion and injection.

# DI and Injection
## Principles and design pattern

Here we will learn the principles(in action) and motivation behind the dependency inversion and injection. 


# Architecture


Things which makes organisation and future exension better: 
1. Create folder and namespaces in project to organise similar and linked classes and their interfaces together.
2. There is no set restrition of following only n-tier folder and namesapces architecture, if you believe the structuring of projects/folders/namespaces are better based on functionality, please go ahead with that way of organisation.
3. Make a habit of segregating the projects based on the high level responsibilities like Data Access, Domain Functionalities, business logic at high level.
4. Create interface for the classes(functionality group) which you think will be used by lot of other classes (DEPENDENCY INVERSION)
5. Use reflection for automation of mapping properties, loading classes in bulk, creating factory instances etc, Point -1, will greatly helps in achieving this.
6. Follow One class - One file rule.
7. Write less code per file.

