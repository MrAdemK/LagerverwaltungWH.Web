using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagerverwaltungWH.Model.ViewModels
{
    public class SelectItemListVM
    {
        [Key]
        public object ValueMember { get; set; }

        public string DisplayMember { get; set; }
    }
}
