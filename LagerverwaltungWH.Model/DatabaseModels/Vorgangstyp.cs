using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Model.DatabaseModels
{
    public class Vorgangstyp
    {
        [Key]
        public int VorgangsId { get; set; }

        [StringLength(7), Required(ErrorMessage = "Vorgang muss ausgewählt werden!")]
        public string Vorgang { get; set; }



        public virtual ICollection<Geschäftsfall> Geschäftsfalle { get; set; }
    }
}
