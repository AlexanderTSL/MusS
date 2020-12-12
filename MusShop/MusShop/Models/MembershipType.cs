using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int  Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int SignUpFree { get; set; }
        public int DurationInMonths { get; set; }
        public int DiscountRate { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
    }
}