using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HATC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public IEnumerable<Character> Characters { get; set;}

    }
}
