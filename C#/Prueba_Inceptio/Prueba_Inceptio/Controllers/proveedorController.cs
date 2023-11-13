using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Prueba_Inceptio.Models.Data;
using Prueba_Inceptio.Operaciones;

namespace Prueba_Inceptio.Controllers
{

    [ApiController]
    public class proveedorController : ControllerBase
    {
        private proveedorOP proveedorOP = new proveedorOP();


        [HttpGet("buscarProveedor")]

        public proveedor getproveedor(String name)
        {
            return proveedorOP.seleccionar(name);
        }

        [HttpPost("agregarProveedor")]

        public bool insertarProveedor([FromBody] proveedor provider)
        {
            return proveedorOP.insertar(provider.Nombre, provider.Direccion, provider.Telefono, provider.Email);
        }

        [HttpPut("modificarProveedor")]
        public bool actualizarproveedor([FromBody] proveedor provider)
        {
            return proveedorOP.actualizar(provider.Id, provider.Nombre, provider.Direccion, provider.Telefono, provider.Email);
        }

        [HttpDelete("quitarProveedor")]

        public bool eliminarproveedor(int id)
        {
            return proveedorOP.eliminar(id);
        }
    }
}
