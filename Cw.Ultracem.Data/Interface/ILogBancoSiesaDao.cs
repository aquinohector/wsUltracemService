using Cw.Ultracem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw.Ultracem.Data.Interface
{
    public interface ILogBancoSiesaDao
    {
        Task<LogBancoSiesa> Add(LogBancoSiesa logBancoSiesa);
    }
}
