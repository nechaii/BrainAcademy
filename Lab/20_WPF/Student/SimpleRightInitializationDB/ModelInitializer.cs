using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRightInitializationDB
{
    using Model;
    using System.Data.Entity;
    using System.IO;

    class ModelInitializer: DbContext
    {
        static ModelInitializer()
        {
            Database.SetInitializer(new ContextInitializer());
        }

        public ModelInitializer() : base("name=StudentDBLocal")
        {
            string dbFolder = "App_Data";
            string appPath = Directory.GetCurrentDirectory();
            string pathToDb = Path.GetFullPath(Path.Combine(appPath, @"..\..\")) + dbFolder;
            AppDomain.CurrentDomain.SetData("DataDirectory", pathToDb);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }
}
