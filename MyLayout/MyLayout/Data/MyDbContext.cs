using Microsoft.EntityFrameworkCore;

namespace MyLayout.Data
{
    public class MyDbContext : DbContext
    {
        #region DbSet
        public DbSet<Loai> Loais { get; set; }
        public DbSet<HangHoa> HangHoas { get; set; }
        #endregion

        public MyDbContext(DbContextOptions options) : base(options)
        { }
    }
}
