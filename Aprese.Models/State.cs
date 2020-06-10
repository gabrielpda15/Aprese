using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models
{
    [Table("LOC_State")]
    public class State : BaseEntityDescription
    {
        [DataType("varchar")]
        [StringLength(2)]
        [ScaffoldColumn(false)]
        public string FederalUnity { get; set; }
    }
}
