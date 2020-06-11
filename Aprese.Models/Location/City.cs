using Aprese.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.Location
{
    [Table("LOC_City")]
    public class City : BaseEntityDescription
    {
        [Required]
        public virtual State State { get; set; }
    }
}
