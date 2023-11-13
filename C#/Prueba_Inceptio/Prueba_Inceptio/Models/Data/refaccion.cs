namespace Prueba_Inceptio.Models.Data
{
    public class refaccion
    {
        public int Id { get; set; }

        public int Proveedor_id {get; set; }
        
        public int Moto_id { get; set; }

        public string Nombre { get; set; } = null!;

        public int Cantidad { get; set; }

        public int Precio_unit { get; set; }

        public virtual proveedor? proveedor { get; set; }

        public virtual vehiculo? vehiculo { get; set; }
    }
}
