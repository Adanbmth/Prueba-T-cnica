using Microsoft.AspNetCore.Mvc;
using Prueba_Inceptio.Models.Data;
using Prueba_Inceptio.Operaciones;

namespace Prueba_Inceptio.Controllers
{
    public class refaccionController : ControllerBase
    {
        private refaccionOP refaccionOP = new refaccionOP();


        [HttpGet("buscarRefaccion")]

        public refaccion getrefaccion(int id)
        {
            return refaccionOP.seleccionarID(id);
        }

        [HttpPost("agregarRefaccion")]

        public bool insertarrefaccion([FromBody] refaccion refaccion)
        {
            return refaccionOP.insertar(refaccion.Nombre, refaccion.Proveedor_id, refaccion.Moto_id, refaccion.Cantidad, refaccion.Precio_unit);
        }

        [HttpPut("modificarRefaccion")]
        public bool actualizarrefaccion([FromBody] refaccion refaccion)
        {
            return refaccionOP.actualizar(refaccion.Id, refaccion.Proveedor_id, refaccion.Moto_id ,refaccion.Nombre, refaccion.Cantidad, refaccion.Precio_unit);
        }

        [HttpDelete("quitarRefaccion")]

        public bool eliminarrefaccion(int id)
        {
            return refaccionOP.eliminar(id);
        }

        [HttpGet("obtenerRefacciones")]
        public List<refaccion> getTodas()
        {
            return refaccionOP.seleccionarTodas();
        }
    }
}

