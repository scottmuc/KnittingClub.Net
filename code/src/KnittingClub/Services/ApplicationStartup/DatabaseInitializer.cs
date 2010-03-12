using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Rhino.Commons;

namespace KnittingClub.Services.ApplicationStartup
{
    public class DatabaseInitializer
    {
        public void InitializeDatabase()
        {            
            var cfg = IoC.Resolve<Configuration>();            
            var schema = new SchemaExport(cfg);
            schema.Create(false, true);
        }
    }
}