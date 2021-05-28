using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerverwaltungWH.Model.Validations;

namespace LagerverwaltungWH.Model.ViewModels
{
    public class GeschäftsfallIndexVM
    {
        [Key]
        public int GeschäftsfallId { get; set; }

        [Display(Name = "Artikel")]
        [StringLength(100), Required(ErrorMessage = "Ware muss betitelt werden!")]
        public string Bezeichnung { get; set; }

        [MengenValidation]
        public int Lagerstand { get; set; }

        [Display(Name = "Mengeneinheit")]
        [StringLength(5), Required(ErrorMessage = "Mengeneinheit muss ausgewählt werden!")]
        public string MengeneinheitBezeichnung { get; set; }

        public int LagerartikelId { get; set; }
    }
}
