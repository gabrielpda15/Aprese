using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Aprese.Models.Security.Relations
{
    [Table("SEC_IdentityRole")]
    public class IdentityRole : IdentityUserRole<int>
    {
    }
}
