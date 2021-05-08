# What is the problem we are trying to solve?
We have a list of advertiser names which might be duplicated among it. Our job is trying to get duplicated ones back.

# Design
The idea is we can utilize MS SQL server full-text search function to solve this problem. 
For example, if we would like to find duplicated name for "Penske" and "Penske System, Inc", we can send our query as this.

![image](https://user-images.githubusercontent.com/17281511/117516809-040a6780-af4f-11eb-9710-41150d214e63.png)

The response will tell us which advertisers are similar "Penske System, Inc". 
It also provides a "RANK" values for relative order of relevance of the rows in the result set.
We can use this "RANK" as a threshold to filter out noises. So we can figure out better candidates from it.

# Prerequisite
- NET 5 (https://dotnet.microsoft.com/download/dotnet/5.0)
- Microsoft SQL Server 2019
  - Download and install instance (https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  - If you have issue to enable full text search feature, please refer to this aritcle. https://stackoverflow.com/questions/63766397/how-to-add-full-text-search-to-sql-server-express-2019-installation)
- Visual Studio 2019
- Checkout source code from this git repository
- Before you run it, make sure you have modified your SQL login credential and connection string settings
  - Change the connection string console application project (Progam.cs)
  ![image](https://user-images.githubusercontent.com/17281511/117517544-28674380-af51-11eb-8d61-3100d24868d3.png)
  - Specify connection string in database project


# How to run it
1. Publish database project to your SQL server instance
This will create a database named "WordAnalysis" and inject test data into this database. (This takes around two minutes on my local environment.)
![image](https://user-images.githubusercontent.com/17281511/117517283-6adc5080-af50-11eb-8839-803cf9dac2b0.png)

2. Execute the console application.
The console application will scan what we stored in the Advertiser table and populate similar ones in alias table.
The whole process might take hours. Then we will see what are the duplicated ones when console application is done.


# Conclusion
This is just a 90 minutes project to demonstrate how to utilize MS SQL full-text search to find similar advertisers.
If we have more time, we can probably invoke 3rd party service (i.e. Google API or Wiki) to verify alias names.
When our model data are good enough, we can create a decision engine to determine this part through cloud (i.e. Azure Cognitive Services.)


