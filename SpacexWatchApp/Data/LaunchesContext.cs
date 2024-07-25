using SpacexWatchApp.Models;

using Microsoft.EntityFrameworkCore;

namespace SpacexWatchApp.Data
{
   public partial class LaunchesContext :DbContext
   {

      public LaunchesContext() {

      }

      public LaunchesContext(DbContextOptions<LaunchesContext> options) : base(options) { }

      public DbSet<SavedLaunches> SavedLaunches { get; set; } = null!;
   }
}
