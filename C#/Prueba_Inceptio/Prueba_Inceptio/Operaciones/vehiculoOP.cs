using Prueba_Inceptio.Context;
using Prueba_Inceptio.Models.Data;

namespace Prueba_Inceptio.Operaciones
{
    public class vehiculoOP
    {
        public tallerContext contexto = new tallerContext();


        public vehiculo seleccionar(String modelo)
        {
            var vehiculo = contexto.vehiculos.Where(a => a.Modelo == modelo).FirstOrDefault();
            return vehiculo;
        }

        public vehiculo seleccionarID(int id)
        {
            var vehiculo = contexto.vehiculos.Where(a => a.Id == id).FirstOrDefault();
            return vehiculo;
        }

        public bool insertar(string marca, string modelo, string año, string tipo)
        {
            try
            {
                vehiculo vehiculo = new vehiculo();
                vehiculo.Marca = marca;
                vehiculo.Modelo = modelo;
                vehiculo.Año = año;
                vehiculo.Tipo = tipo;

                contexto.vehiculos.Add(vehiculo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizar(int id, string marca, string modelo, string año, string tipo)
        {
            try
            {
                var vehiculo = seleccionarID(id);

                if (vehiculo == null)
                {
                    return false;
                }
                else
                {
                    vehiculo.Marca = marca;
                    vehiculo.Modelo = modelo;
                    vehiculo.Año = año;
                    vehiculo.Tipo = tipo;

                    contexto.SaveChanges();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var vehiculo = seleccionarID(id);
                if (vehiculo == null)
                {
                    return false;
                }
                else
                {
                    contexto.vehiculos.Remove(vehiculo);
                    contexto.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
