using Prueba_Inceptio.Context;
using Prueba_Inceptio.Models.Data;

namespace Prueba_Inceptio.Operaciones
{
    public class proveedorOP
    {
        public tallerContext contexto = new tallerContext();


        public proveedor seleccionar (String nombre) 
        {
            var provider = contexto.proveedors.Where(a => a.Nombre == nombre).FirstOrDefault();
            return provider;
        }

        public proveedor seleccionarID(int id)
        {
            var provider = contexto.proveedors.Where(a => a.Id == id).FirstOrDefault();
            return provider;
        }

        public bool insertar(string nombre, string direccion, string telefono, string email)
        { 
            try
            {
                proveedor provider = new proveedor();
                provider.Nombre = nombre;
                provider.Direccion = direccion;
                provider.Telefono = telefono;
                provider.Email = email;

                contexto.proveedors.Add(provider);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }

        public bool actualizar(int id, string nombre, string direccion, string telefono, string email)
        {
            try 
            {
                var provider = seleccionarID(id);

                if(provider == null)
                {
                    return false;
                }
                else
                {
                    provider.Nombre = nombre;
                    provider.Direccion = direccion;
                    provider.Telefono = telefono;
                    provider.Email = email;

                    contexto.SaveChanges();
                    return true;
                }
                
            }
            catch(Exception ex) 
            { 
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var provider = seleccionarID(id);
                if (provider == null)
                {
                    return false;
                }
                else 
                {
                    contexto.proveedors.Remove(provider);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch(Exception ex) 
            {
                return false;
            }
        }
    }
}
