using System.ComponentModel.DataAnnotations;

namespace ProductosRepaso.Dtos
{
    public class UserDto
    {
        [Required]
        public string usuario { get; set; }
        public string clave { get; set; }
    }
}
