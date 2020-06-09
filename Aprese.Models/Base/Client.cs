using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.Base
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [DataType("varchar")]
        [StringLength(70)]
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
