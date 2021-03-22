using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Respawn;

namespace Application.IntegrationTests
{
    public class DbFixture
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfigurationRoot _configuration;
        private readonly Checkpoint _checkpoint;

        public DbFixture(ApplicationDbContext context, IConfigurationRoot configuration)
        {
            _context = context;
            _configuration = configuration;
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new []{ "__EFMigrationsHistory" },
                DbAdapter = DbAdapter.Postgres
            };
            
            EnsureDatabase();
        }

        public ApplicationDbContext DbContext()
        {
            return _context;
        }

        public void EnsureDatabase()
        {
            _context.Database.Migrate();
        }


        public void ResetState()
        {
            _context.Database.OpenConnection();
            _checkpoint.Reset(_context.Database.GetDbConnection())
                .GetAwaiter()
                .GetResult();
        }
    }
}