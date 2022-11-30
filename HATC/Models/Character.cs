using System.ComponentModel.DataAnnotations;

namespace HATC.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
    }
}
