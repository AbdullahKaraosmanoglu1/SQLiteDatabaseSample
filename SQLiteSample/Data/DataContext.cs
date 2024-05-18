using Microsoft.EntityFrameworkCore;
using SQLiteSample.Entities;

namespace SQLiteSample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RpgCharacter> RpgCharacters => Set<RpgCharacter>();
    }
}
