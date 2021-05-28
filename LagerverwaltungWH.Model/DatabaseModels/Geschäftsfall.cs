using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LagerverwaltungWH.Model.DatabaseModels
{
    public class Geschäftsfall
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




        public int LagerartikelId { get; set; }
        public virtual Lagerartikel Lagerartikel { get; set; }

        public int LagerbewegungsId { get; set; }
        public virtual Lagerbewegung Lagerbewegung { get; set; }

        public int VorgangsId { get; set; }
        public virtual Vorgangstyp Vorgangstyp { get; set; }
    }
}
