using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cw.Ultracem.BL.Implementacion;
using Cw.Ultracem.DTO.Banco;
using System.Threading.Tasks;

namespace Cw.Ultracem.UnitTest
{
    [TestClass]
    public class ConfirmarTest
    {

        /// <summary>
        /// Metodo que prueba que cuando no se mande el numero de autorización responda el error especifico.
        /// </summary>
        //[TestMethod]
        //public void ConfirmarReferenciaErrada()
        //{
        //    var confirmarBL = new ServiceUltracemBL();

        //    ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
        //    confirmarRecaudoInputDto.Referencia1 = "-1";

        //    ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = confirmarBL.ConfirmarRecaudo(confirmarRecaudoInputDto);

        //    Assert.AreEqual("10", confirmarRecaudoOutputDto.ErrorCodigo);
        //    Assert.AreEqual("Numero de factura errado, verifique la referencia 1", confirmarRecaudoOutputDto.ErrorDescripcion);
        //}

        /// <summary>
        /// Metodo que prueba que cuando no se mande el numero de autorización responda el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ConfirmarAutorizacionNuloAsync()
        {
            var confirmarBL = new ServiceUltracemBL();

            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
            confirmarRecaudoInputDto.nro_autorizacion = null;

            ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await confirmarBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);

            Assert.AreEqual("1", confirmarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Numero de autorización vacío", confirmarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande el usuario responda el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ConfirmarUsuarioNulo()
        {
            var confirmarBL = new ServiceUltracemBL();

            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
            confirmarRecaudoInputDto.usuario = null;

            ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await confirmarBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);

            Assert.AreEqual("2", confirmarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Usuario invalido", confirmarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande la clave responda el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ConfirmarClaveNulo()
        {
            var confirmarBL = new ServiceUltracemBL();

            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
            confirmarRecaudoInputDto.clave = null;

            ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await confirmarBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);

            Assert.AreEqual("3", confirmarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("Clave invalida", confirmarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande el valor en efectivo responda el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ConfirmarEfectivoNulo()
        {
            var confirmarBL = new ServiceUltracemBL();

            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
            confirmarRecaudoInputDto.efectivo = null;

            ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await confirmarBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);

            Assert.AreEqual("4", confirmarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("El valor en efectivo es invalido", confirmarRecaudoOutputDto.ErrorDescripcion);
        }

        /// <summary>
        /// Metodo que prueba que cuando no se mande el valor total responda el error especifico.
        /// </summary>
        [TestMethod]
        public async Task ConfirmarTotalNulo()
        {
            var confirmarBL = new ServiceUltracemBL();

            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = this.CargarConfirmar();
            confirmarRecaudoInputDto.total_transaccion = null;

            ConfirmarRecaudoOutputDto confirmarRecaudoOutputDto = await confirmarBL.ConfirmarRecaudoAsync(confirmarRecaudoInputDto);

            Assert.AreEqual("5", confirmarRecaudoOutputDto.ErrorCodigo);
            Assert.AreEqual("El valor total de la transaccion es invalido", confirmarRecaudoOutputDto.ErrorDescripcion);
        }

        #region Metodos Privados

        private ConfirmarRecaudoInputDto CargarConfirmar()
        {
            ConfirmarRecaudoInputDto confirmarRecaudoInputDto = new ConfirmarRecaudoInputDto()
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
                nro_autorizacion = "2019031196947905",
                ch_propios = "00000000000000000",
                clave = "0cc1d3nt3",
                nombre_pagador = "Karen Meneses",
                cod_producto = "05",
                jornada = "1",
                fecha_transaccion = "20190212",
                operador = "67280",
                referencia1 = "1130670801",
                referencia2 = "200526710",
                nro_docto_adic = "000000000000000200526710",
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

            return confirmarRecaudoInputDto;
        }

        #endregion

    }
}
