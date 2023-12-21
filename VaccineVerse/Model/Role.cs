using System.ComponentModel.DataAnnotations;

namespace VaccineVerse.Model
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public string RoleName {  get; set; }
    }
}
