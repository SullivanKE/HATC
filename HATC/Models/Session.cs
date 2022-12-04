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
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public IEnumerable<SessionItem> SessionItems {get; set;} = new List<SessionItem>();
        public IEnumerable<Monster> Monsters { get; set; } = new List<Monster>();
        public DateTime Date { get; set; }
    }
}
