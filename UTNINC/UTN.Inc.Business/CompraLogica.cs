using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Inc.Data.Repository;
using UTN.Inc.Entities;

namespace UTN.Inc.Business
{
    public class CompraLogica
    {
        private readonly CompraRepository _compraRepository;

        public CompraLogica(CompraRepository compraRepo)
        {
            _compraRepository = compraRepo;
        }


        //METODO PARA SUMAR AL STOCK
        public async Task<bool> SumarStock(DateTime fecha, int productoId, int cantidad, int usuarioId)
        {
            //FECHA, PRODUCTOID, CANTIDAD, USUARIOID

            //FECHA
            //DateTime fechaHora = 

            //PRODUCTO ID
            int pId = 0;

            //CANTIDAD
            int cant = 0;

            //USUARIOID
            int usId = 0;

            //SI TODO ESTA BIEN
            if ((cant != 0) && (usId != 0) && (pId != 0))
            {
                var stock = await _compraRepository.ChequearStock(pId) + cant;


                Compra compra = new()
                {
                    //Fecha = lafecha,
                    ProductoId = pId,
                    Cantidad = stock,
                    UsuarioId = usId,
                };

                _compraRepository.ModificarStock(compra);
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}