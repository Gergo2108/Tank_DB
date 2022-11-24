using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Models
{
   public class Battle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

      
        public virtual ICollection<Tank> Tanks { get; set; }
        
        public virtual ICollection<Country> Countries { get; set; }

        public Battle()
        {
            Tanks = new HashSet<Tank>();
            Countries = new HashSet<Country>();
        }

        public override string ToString()
        {
            return $"#{Id}-Battle: Name = {Name}, ";
        }
    }
}
