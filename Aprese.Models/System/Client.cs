using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.System
{
    [Table("SIS_Client")]
    public class Client : BaseEntity
    {
        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string Name { get; set; }

        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string Naturality { get; set; }

        [DataType("varchar")]
        [StringLength(15)]
        [ScaffoldColumn(false)]
        public string CPF { get; set; }

        [DataType("varchar")]
        [StringLength(19)]
        [ScaffoldColumn(false)]
        public string CNPJ { get; set; }
    }
}
