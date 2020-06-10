using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aprese.Models
{
    public class City : BaseEntity
    {
        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string FederalUnity { get; set; }

        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string StateName { get; set; }
    }
}
