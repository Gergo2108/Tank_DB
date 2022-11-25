using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K9P4EG_HFT_2022231.Models
{
   public class Tank
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
        public int GunSize { get; set; }
        [NotMapped]
        public virtual Country Country { get; set; }
       [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
       [NotMapped]
        public virtual  Battle Battle { get; set; }
        [ForeignKey(nameof(Battle))]
        public int BattleId { get; set; }
        public Tank()
        {
            
        }

        public override string ToString()
        {
            return $"#{Id}-Tank: MODEL = {Model}, Weight: {Weight} Tons, Gunsize: {GunSize} mm, " +
                $"Country : {Country} Id: {CountryId}, Battle: {Battle} Id: {BattleId},";
        }
       
    }
}
