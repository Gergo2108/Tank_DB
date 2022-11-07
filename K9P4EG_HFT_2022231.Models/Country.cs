using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Models
{
   public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tank> Tanks { get; set; }

        public Country()
        {
            Tanks = new HashSet<Tank>();
        }

        public override string ToString()
        {
            return $"#{Id}-Country: Name = {Name}";
        }
    }
}
