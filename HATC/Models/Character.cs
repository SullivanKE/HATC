using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace HATC.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public User Player { get; set; }

    }
}
