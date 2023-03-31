# MovieRecommendation

- This project is ASP.NET Core Web Api project.
- .Net 6 version is used
- If you want to run the project, you must first specify your own data source in **MovieRecommendation.API** and **appsettings.json** file in **ConnectionString** “`Data Source=yourdatasource“`
- And then you must create the database.
- You must select **MovieRecommendation.DataAccessLayer** as Default Project in **Package Manager Console**. You must add these commands:
- “`
add-migration initial 
  “`
- “`
Update-Database
  “`
- If you want data to be saved to the database, you need to open the comment about Quartz in **MovieRecommendation.API** in **program.cs**
- You can run the project.
