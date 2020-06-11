using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.Configuration
{
    [Table("CFG_Status")]
    public class Status : BaseEntity
    {
        [DataType("varchar")]
        [StringLength(50)]
        [ScaffoldColumn(false)]
        public string Name { get; set; }
    }
}
