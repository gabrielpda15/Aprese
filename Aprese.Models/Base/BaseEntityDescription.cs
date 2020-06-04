using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aprese.Models.Base
{
    public class BaseEntityDescription : BaseEntity
    {
        [Required]
        [DataType("varchar")]
        [StringLength(255)]
        [ScaffoldColumn(false)]
        public virtual string Description { get; set; }
    }
}
