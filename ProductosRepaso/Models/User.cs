namespace ProductosRepaso.Models
{
    public class User(string usuario, string password)
    {
        public string Usuario { get; set; } = usuario;
        public string Password { get; set; } = password;
    }
}