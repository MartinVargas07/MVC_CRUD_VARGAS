namespace MVC_CRUD_VARGAS.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Clave { get; set; }
        public string Email { get; set; } // Si estás utilizando el email para el login
    }
}
