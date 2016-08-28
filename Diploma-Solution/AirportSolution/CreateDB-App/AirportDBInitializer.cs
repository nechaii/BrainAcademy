using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB_App
{
    using System.Data.Entity;
    /*
     * варианты инициализации БД
     * Database.SetInitializer(new DropCreateDatabaseAlways<CodeContext>());
     * Database.SetInitializer(new CreateDatabaseIfNotExists<CodeContext>());
     * Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CodeContext>());
     * Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportContext, CreateDB-App.Migrations.Configuration>());
    */

    /*
     * MigrateDatabaseToLatestVersion
     * NuGet: enable - migrations для проекта в котором инициализируем БД
     * Database.SetInitializer(new MigrateDatabaseToLatestVersion<AirportContext, CreateDB-App.Migrations.Configuration>());
     * ручная миграция NuGet: Add - Migration
     * в конфиг кидаем коннект к БД, в NuGet: Update-Database -Verbose
    */


    //Команды для миграции 

    //Install-Package EntityFramework  
    //Enable-Migrations –EnableAutomaticMigrations
    //Update-Database
    //Add-Migration Name Migrations
    //Update-Database –Verbose

    public class AirportDBInitializer: DropCreateDatabaseIfModelChanges<AirportContext>
    {
        protected override void Seed(AirportContext context)
        {
            base.Seed(context);
            //Program.CreateAirLine();
        }

    }
}
