using Aprese.Models.Base;
using Aprese.Models.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.System
{
    public enum ClientType { Company, Person }

    public class CompanyClient : Client
    {
        [DataType("varchar")]
        [StringLength(19)]
        [ScaffoldColumn(false)]
        public string CNPJ { get; set; }

        [DataType("varchar")]
        [StringLength(120)]
        [ScaffoldColumn(false)]
        public string CompanyName { get; set; }

        [DataType("varchar")]
        [StringLength(120)]
        [ScaffoldColumn(false)]
        public string TradingName { get; set; }
    }

    public class PersonClient : Client
    {
        [DataType("varchar")]
        [StringLength(15)]
        [ScaffoldColumn(false)]
        public string CPF { get; set; }

        [DataType("varchar")]
        [StringLength(30)]
        [ScaffoldColumn(false)]
        public string FirstName { get; set; }

        [DataType("varchar")]
        [StringLength(80)]
        [ScaffoldColumn(false)]
        public string LastName { get; set; }
    }

    [Table("SIS_Client")]
    public class Client : BaseEntity
    {
        [Required]
        public virtual City City { get; set; }

        public ClientType Type { get; set; }
    }
}
