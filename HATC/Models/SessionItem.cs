using System.ComponentModel.DataAnnotations;

namespace HATC.Models
{
    public class SessionItem
    {
        [Key]
        public int SessionItemId { get; set; }
        public string ItemName { get; set; } = "";
        public int Value { get; set; }
        public enum ItemType
        {
            Adhoc,
            Item
        }
        public ItemType Type { get; set; } = ItemType.Adhoc;
    }
}
