using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DB
{
    using System.Data.Entity;
    using System.IO;
    using Student.Model;

    public class StudentDB: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }


        public StudentDB(): base("StudentDBLocal")
        {
            string dbFolder = "App_Data";
            string appPath = Directory.GetCurrentDirectory();
            string pathToDb = Path.GetFullPath(Path.Combine(appPath, @"..\..\")) + dbFolder;
            AppDomain.CurrentDomain.SetData("DataDirectory", pathToDb);
        }
    }
}
