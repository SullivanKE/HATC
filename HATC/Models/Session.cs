using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HATC.Models
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public string DM { get; set; }
        public string InGameDate { get; set; }
        public DateTime SessionDate { get; set; }
        public List<User> Users { get; set; } = new List<User>();
        public List<SessionItem> SessionItems {get; set;} = new List<SessionItem>();
        public List<Monster> Monsters { get; set; } = new List<Monster>();
    }
}
