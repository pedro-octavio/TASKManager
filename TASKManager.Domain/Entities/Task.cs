using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TASKManager.Domain.Entities
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Descripton { get; set; }
        public int Importancy { get; set; }
        [DefaultValue(false)]
        public bool IsActive { get; set; }
    }
}
