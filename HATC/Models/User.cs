using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HATC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public enum RoleType
        {
            Player,
            DM
        }
        public RoleType Role { get; set; }

    }
}
