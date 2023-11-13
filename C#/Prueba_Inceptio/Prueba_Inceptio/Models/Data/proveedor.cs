namespace Prueba_Inceptio.Models.Data
{
    public class proveedor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<refaccion> Refacciones { get; set; } = new List<refaccion>();
    }
}
