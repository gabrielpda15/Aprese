using Aprese.Models.Base;
using Aprese.Models.Configuration;
using Aprese.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.System
{
    [Table("SIS_Task")]
    public class Task : BaseEntityDescription
    {
        public DateTime? LimitDate { get; set; }

        [Required]
        public virtual Client Client { get; set; }

        [Required]
        public virtual Identity Identity { get; set; }


        public virtual Status Status { get; set; }
    }
}
