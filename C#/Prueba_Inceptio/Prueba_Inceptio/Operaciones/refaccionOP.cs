using Prueba_Inceptio.Context;
using Prueba_Inceptio.Models.Data;

namespace Prueba_Inceptio.Operaciones
{
    public class refaccionOP
    {
        public tallerContext contexto = new tallerContext();

        public List<refaccion> seleccionarTodas()
        {
            var refacciones = contexto.refaccions.ToList<refaccion>();
            return refacciones;
        }
        public refaccion seleccionar(String nombre)
        {
            var refaccion = contexto.refaccions.Where(a => a.Nombre == nombre).FirstOrDefault();
            return refaccion;
        }

        public refaccion seleccionarMashin(int id, int proveedor_id, int moto_id) 
        {
            var refacc = contexto.refaccions.Where(a => a.Id == id & a.Proveedor_id == proveedor_id & a.Moto_id == moto_id).FirstOrDefault();
            return refacc;
        }

        public refaccion seleccionarID(int id)
        {
            var refaccion = contexto.refaccions.Where(a => a.Id == id).FirstOrDefault();
            return refaccion;
        }

        public bool insertar(string nombre,int proveedor_id, int moto_id, int cantidad, int precio)
        {
            try
            {
                refaccion refaccion = new refaccion();
                refaccion.Nombre = nombre;
                refaccion.Proveedor_id = proveedor_id;
                refaccion.Moto_id = moto_id;
                refaccion.Cantidad = cantidad;
                refaccion.Precio_unit = precio;

                contexto.refaccions.Add(refaccion);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizar(int id, int proveedor_id, int moto_id, string nombre, int cantidad, int precio)
        {
            try
            {
                var refaccion = seleccionarID(id);

                if (refaccion == null)
                {
                    return false;
                }
                else
                {
                    refaccion.Proveedor_id = proveedor_id;
                    refaccion.Moto_id = moto_id;
                    refaccion.Nombre = nombre;
                    refaccion.Cantidad= cantidad;
                    refaccion.Precio_unit= precio;

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
                var refaccion = seleccionarID(id);

                if (refaccion == null)
                {
                    return false;
                }
                else
                {
                    contexto.refaccions.Remove(refaccion);
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
