using System;
using System.Collections.Generic;
using System.Text;

namespace Aprese.Models.Base
{
    public interface IEntity
    {
        int Id { get; set; }
        string EditionUser { get; set; }
        string CreationUser { get; set; }
        string EditionIp { get; set; }
        string CreationIp { get; set; }
        DateTime? EditionDate { get; set; }
        DateTime? CreationDate { get; set; }
    }
}
