using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Cod.Models
{
    [Table("Newsletters")]
    public class Newsletter
    {
        [Key]
        public int NewsletterId { get; set; }
        public string Email { get; set; }
        public string FavoriteFish { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
