using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Model.DatabaseModels
{
    public class Mengeneinheit
    {
        [Key]
        public int MengeneinheitId { get; set; }

        [Display(Name = "Mengeneinheit")]
        [StringLength(5), Required(ErrorMessage = "Mengeneinheit muss ausgewählt werden!")]
        public string MengeneinheitBezeichnung { get; set; }


        public virtual ICollection<Lagerartikel> Lagerartikeln { get; set; }
    }
}
