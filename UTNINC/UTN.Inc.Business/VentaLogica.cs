using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Data.Repository;
using UTN.Inc.Entities;

namespace UTN.Inc.Business
{
    public class VentaLogica
    {
        private readonly VentaRepository _ventaRepository;

        public VentaLogica(VentaRepository ventaRepo)
        {
            _ventaRepository = ventaRepo;
        }

        //METODO PARA RESTAR AL STOCK
        public async Task<bool> RestarStock(int productoId, int cantidad, int usuarioId)
        {
            //FECHA VENTA
            DateOnly fecha = DateOnly.FromDateTime(DateTime.Now);


            //PRODUCTO ID
            int pId = productoId;

            //CANTIDAD
            int cant = cantidad;

            //USUARIOID
            int usId = usuarioId;

            //SI TODO ESTA BIEN
            if ((cant != 0) && (usId != 0) && (pId != 0))
            {
                //COMPROBAR QUE EL STOCK NO SEA MENOR O IGUAL A 0

                var stock = await _ventaRepository.ChequearStock(pId);

                if ((stock > 0) && (cant <= stock))
                {

                    Venta venta = new()
                    {
                        Fecha = fecha,
                        ProductoId = pId,
                        Cantidad = cant,
                        UsuarioId = usId

                    };
                    _ventaRepository.ModificarStock(venta);
                    return true;

                }


            }
            return false;

        }
        public List<Venta> ListarVentas()
        {
            var result = _ventaRepository.ObtenerVentas();
            return result;
        }

        public IQueryable<VentaDTO> ListarVentasConDatos()
        {
            var result = _ventaRepository.ObtenerVentasFull();
            return result;
        }
    }
}