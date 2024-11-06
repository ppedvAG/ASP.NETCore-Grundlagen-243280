using BusinessLogic.Data;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Test
{
    internal class TestDatabase
    {
        private const string ConnectionString = "Data Source=(localdb)\\AspNetCoreKurs;Initial Catalog=UnitTests;Integrated Security=True;MultipleActiveResultSets=True";
        private static readonly object _lock = new();
        private static bool _dbInitialized = false;

        private DemoDbContext _demoDbContext;

        public DemoDbContext Context => _demoDbContext ??= CreateContext();

        private DemoDbContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<DemoDbContext>().UseSqlServer(ConnectionString);
            var context = new DemoDbContext(builder.Options);
            return context;
        }

        public TestDatabase()
        {
            lock (_lock)
            {
                if (!_dbInitialized)
                {
                    using var context = CreateContext();

                    // Sicherstellen, dass Testausgangszustand immer identisch ist
                    context.Database.EnsureDeleted();

                    // Datenbank erzeugen
                    //context.Database.EnsureCreated();

                    // Datenbank erzeugen und Daten migrieren
                    context.Database.Migrate();

                    _dbInitialized = true;
                }
            }
        }
    }
}
