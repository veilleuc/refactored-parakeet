# refactored-parakeet
Parakeet is a clothing store built on Asp.net core MVC. It is inspired by sites such as RedBubble. This project is a team project for CSCI 540 "Software Engineering" at USC Upstate. 

# Team git info
When pushing, Please give the other team members a notice so they can "git pull" the latest updates to the project. 
Make sure not to work on a file that someone else is working on because it can cause issues when trying to combine here on GitHub.

# General Instructions
When pulling down the project for the first time you will need to change the appsettings.json connectionstring that is related to your name.

afterwards go to the Startup.cs and find the configureservices() method. In this you will change the the Configuration.GetConnectionString("JaredConnection"))); to your Json connection string name.

you will then need to do a Add-Migration and Update-Database to get your database built and running. Also your migration name should be related to your name ( i.e "jaredinitialcreate" ) so that two people do not create the same migration file which will cause issues with git push.

Please use pull and commit often so that your project stays up to date. However only use Push when the project is at a good point.
