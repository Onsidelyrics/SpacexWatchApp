using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SpacexWatchApp.Models
{
   public class SavedLaunches
   {
      [Key]
      [DatabaseGenerated( DatabaseGeneratedOption.None )]
      public int FlightNumber { get; set; }

      public string Name { get; set; } = null!; 

      public bool Upcoming { get; set; }
   }
}
