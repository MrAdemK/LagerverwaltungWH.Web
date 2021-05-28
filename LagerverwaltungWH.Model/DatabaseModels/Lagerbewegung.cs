using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Model.DatabaseModels
{
    public class Lagerbewegung
    {
        [Key]
        public int LagerbewegungsId { get; set; }

        [Display(Name = "Menge")]
        public int LB_Menge { get; set; }



        public virtual ICollection<Geschäftsfall> Geschäftsfalle { get; set; }
    }
}
