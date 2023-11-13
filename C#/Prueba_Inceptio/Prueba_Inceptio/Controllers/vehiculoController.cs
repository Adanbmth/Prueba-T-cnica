using Microsoft.AspNetCore.Mvc;
using Prueba_Inceptio.Models.Data;
using Prueba_Inceptio.Operaciones;

namespace Prueba_Inceptio.Controllers
{
    public class vehiculoController : ControllerBase
    {
        private vehiculoOP vehiculoOP = new vehiculoOP();


        [HttpGet("buscarVehiculo")]

        public vehiculo getvehiculo(String modelo)
        {
            return vehiculoOP.seleccionar(modelo);
        }

        [HttpPost("agregarVehiculo")]

        public bool insertarvehiculo([FromBody] vehiculo vehiculo)
        {
            return vehiculoOP.insertar(vehiculo.Marca, vehiculo.Modelo, vehiculo.Año, vehiculo.Tipo);
        }

        [HttpPut("modificarVehiculo")]
        public bool actualizarvehiculo([FromBody] vehiculo vehiculo)
        {
            return vehiculoOP.actualizar(vehiculo.Id, vehiculo.Marca, vehiculo.Modelo, vehiculo.Año, vehiculo.Tipo);
        }

        [HttpDelete("quitarVehiculo")]

        public bool eliminarvehiculo(int id)
        {
            return vehiculoOP.eliminar(id);
        }
    }
}
