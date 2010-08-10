using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Rhino.Commons;
using System.IO;
using System;

namespace KnittingClub.Services.ApplicationStartup
{
    public class DatabaseInitializer
    {
        public void InitializeDatabase()
        {
            if (IsInitialized())
                return;

            var cfg = IoC.Resolve<Configuration>();
            var schema = new SchemaExport(cfg);
            schema.Create(false, true);

        }

        public bool IsInitialized()
        {
            string dbfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"app_data\knittingclub.db");

            return File.Exists(dbfile);
        }
    }
}