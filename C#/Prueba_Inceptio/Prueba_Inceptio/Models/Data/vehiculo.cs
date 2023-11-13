namespace Prueba_Inceptio.Models.Data
{
    public class vehiculo
    {
        public int Id { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Año { get; set; } = null!;

        public string Tipo { get; set; } = null!;

        public virtual ICollection<refaccion> Refacciones { get; set; } = new List<refaccion>();

    }
}
