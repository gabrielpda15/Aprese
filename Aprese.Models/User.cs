using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aprese.Models
{
    public class User : BaseEntity
    {
        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string Category { get; set; }

        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string Type { get; set; }

        [DataType("varchar")]
        [StringLength(15)]
        [ScaffoldColumn(false)]
        public string CPF { get; set; }

        [DataType("varchar")]
        [StringLength(20)]
        [ScaffoldColumn(false)]
        public string Password { get; set; }
    }
}
