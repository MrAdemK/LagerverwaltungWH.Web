using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerverwaltungWH.Model.Validations;

namespace LagerverwaltungWH.Model.DatabaseModels
{
    public class Lagerartikel
    {
        [Key]
        public int LagerartikelId { get; set; }

        [Display(Name = "Artikel")]
        [StringLength(100), Required(ErrorMessage = "Ware muss betitelt werden!")]
        public string Bezeichnung { get; set; }

        [DataType(DataType.Currency)]
        public decimal Preis { get; set; }

        [MengenValidation]
        public int Lagerstand { get; set; }


        
        public int MengeneinheitId { get; set; }
        public virtual Mengeneinheit Mengeneinheit { get; set; }

        public virtual ICollection<Geschäftsfall> Geschäftsfalle { get; set; }
    }
}
