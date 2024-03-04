using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cw.Ultracem.BL.Implementacion;
using Cw.Ultracem.DTO.Banco;
using System.Threading.Tasks;

namespace Cw.Ultracem.UnitTest
{
    [TestClass]
    public class ReferenciarTest
    {
        /// <summary>
        /// La premisa para poder ejecutar este test es asegurar que hay un registro de recaudo que cumple con los datos de la referencia, se hace de esta manera porque no se tiene forma de insertar un recaudo.
        /// </summary>
        [TestMethod]
        public async Task ReferenciarExistenteTest()
        {
            var referenciarBL = new ServiceUltracemBL();

            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = this.CargarReferencia();
            referenciarRecaudoInputDto.referencia1 = "890115406";

            ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await referenciarBL.ReferenciarRecaudo(referenciarRecaudoInputDto);

            Assert.AreEqual("0", referenciarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual(string.Empty, referenciarRecaudoOutputDto.ErrorDescripcion);

        }

        /// <summary>
        /// Metodo que prueba que cuando se busque un recaudo que no exista devuelva un error
        /// </summary>
        [TestMethod]
        public async Task ReferenciarNoExiste()
        {
            var referenciarBL = new ServiceUltracemBL();

            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = this.CargarReferencia();
            referenciarRecaudoInputDto.referencia1 = "-1";

            ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await referenciarBL.ReferenciarRecaudo(referenciarRecaudoInputDto);

            Assert.AreEqual("10", referenciarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("El recaudo no existe", referenciarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande la clave responda con el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ReferenciarReferenciaNulo()
        {
            var referenciarBL = new ServiceUltracemBL();

            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = this.CargarReferencia();
            referenciarRecaudoInputDto.referencia1 = null;

            ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await referenciarBL.ReferenciarRecaudo(referenciarRecaudoInputDto);

            Assert.AreEqual("1", referenciarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Referencia 1 vacía", referenciarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande el usuario responda con el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ReferenciarUsuarioNulo()
        {
            var referenciarBL = new ServiceUltracemBL();

            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = this.CargarReferencia();
            referenciarRecaudoInputDto.usuario = null;


            ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await referenciarBL.ReferenciarRecaudo(referenciarRecaudoInputDto);

            Assert.AreEqual("2", referenciarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Usuario invalido", referenciarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande la clave responda con el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ReferenciarClaveNulo()
        {
            var referenciarBL = new ServiceUltracemBL();

            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = this.CargarReferencia();
            referenciarRecaudoInputDto.clave = null;

            ReferenciarRecaudoOutputDto referenciarRecaudoOutputDto = await referenciarBL.ReferenciarRecaudo(referenciarRecaudoInputDto);

            Assert.AreEqual("3", referenciarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Clave invalida", referenciarRecaudoOutputDto.ErrorDescripcion);
        }


        #region Metodos Privados

        private ReferenciarRecaudoInputDto CargarReferencia()
        {
            ReferenciarRecaudoInputDto referenciarRecaudoInputDto = new ReferenciarRecaudoInputDto()
            {
                nro_registros = "1",
                ind_notificacion = "0",
                ind_extemporaneidad = "2",
                canal = "99",
                nro_cuenta = "016066664",
                cod_operacion = "27322",
                total_transaccion = "00000000024000000",
                tipo_registro = "390",
                canje = "00000000000000000",
                ch_propios = "00000000000000000",
                clave = "0cc1d3nt3",
                nro_terminal = "077-43",
                ind_recaudo = "00",
                nombre_pagador = "Karen Meneses",
                cod_producto = "05",
                jornada = "1",
                fecha_transaccion = "20190212",
                operador = "67280",
                referencia1 = "1130670801",
                referencia2 = "200526710",
                nro_docto_adicional = "000000000000000200526710",
                cod_empresa = "01924",
                oficina = "077",
                ingreso_vario = "00000000000000000",
                hora_transaccion = "154245",
                usuario = "boccidente",
                nro_docto = "01130670801",
                arreglo_1_9 = "EXITOSO SAM",
                cod_banco = "023",
                efectivo = "00000000024000000"

            };

            return referenciarRecaudoInputDto;
        }

        #endregion
    }
}
