using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Model.ViewModels
{
    public class GeschäftsfallListVM
    {
        [Key]
        public int GeschäftsfallId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Datum { get; set; }

        [Display(Name = "Erstellt von")]
        public string ErstelltVon { get; set; }

        [Display(Name = "Geändert von")]
        public string GeändertVon { get; set; }

        [Key]
        public int LagerartikelId { get; set; }

        [Display(Name = "Artikel")]
        [StringLength(100), Required(ErrorMessage = "Ware muss betitelt werden!")]
        public string Bezeichnung { get; set; }

        [Display(Name = "Menge")]
        public int LB_Menge { get; set; }

        [StringLength(7), Required(ErrorMessage = "Vorgang muss ausgewählt werden!")]
        public string Vorgang { get; set; }
    }
}
