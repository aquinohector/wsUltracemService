using Cw.Ultracem.DTO.Banco;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cw.Ultracem.BL.Interface
{
    public interface IServiceUltracemBL
    {
        /// <summary>
        /// Metodo que implementa la logica de referenciar recaudo
        /// </summary>
        /// <param name="referenciarRecaudoInput"></param>
        /// <returns></returns>
        Task<ReferenciarRecaudoOutputDto> ReferenciarRecaudo(ReferenciarRecaudoInputDto referenciarRecaudoInput);

        /// <summary>
        /// Metodo que implementa la logica de confirmación de recaudo
        /// </summary>
        /// <param name="confirmarRecaudoInputDto"></param>
        /// <returns></returns>
        Task<ConfirmarRecaudoOutputDto> ConfirmarRecaudoAsync(ConfirmarRecaudoInputDto confirmarRecaudoInputDto);

        /// <summary>
        /// Metodo que implementa la logica de reversión de recaudo
        /// </summary>
        /// <param name="reversarRecaudoInputDto"></param>
        /// <returns></returns>
        Task<ReversarRecaudoOutputDto> ReversarRecaudoAsync(ReversarRecaudoInputDto reversarRecaudoInputDto);

        /// <summary>
        /// Metodo de consulta de recaudos
        /// </summary>
        /// <param name="consultarRecaudoInputDto"></param>
        /// <returns></returns>
        Task<ConsultarRecaudoOutputDto> ConsultarRecaudoAsync(ConsultarRecaudoInputDto consultarRecaudoInputDto);
    }
}
