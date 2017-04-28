using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cod.Models
{
    [Table("Promos")]
    public class Promo
    {
       [Key]
       public int PromoId { get; set; }
       public string FishOfDay { get; set; }
       public string Special { get; set; }
       public string ImageUrl { get; set; }
       public string OurStory { get; set; }
       public string Hours { get; set; }
       public virtual ApplicationUser User { get; set; }
    }
}
