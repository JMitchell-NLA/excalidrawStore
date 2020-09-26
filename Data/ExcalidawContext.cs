using Microsoft.EntityFrameworkCore;

namespace excalidrawCloud.Data
{
    public class ExcalidrawContext : DbContext
    {
        public ExcalidrawContext (
            DbContextOptions<ExcalidrawContext> options)
            : base(options)
        {
        }

        public DbSet<excalidrawCloud.Models.Excalidraw> Excalidraws { get; set; }
        public DbSet<excalidrawCloud.Models.ExcalidrawHistory> ExcalidrawHistories { get; set; }
    }
}