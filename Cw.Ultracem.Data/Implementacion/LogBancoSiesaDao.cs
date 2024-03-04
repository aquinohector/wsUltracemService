using Cw.Ultracem.Data.Interface;
using Cw.Ultracem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw.Ultracem.Data.Implementacion
{
    public class LogBancoSiesaDao : ILogBancoSiesaDao
    {
        /// <summary>
        /// Contexto para realizar las transacciones en BD
        /// </summary>
        private UltracemDB db;

        public LogBancoSiesaDao()
        {
            db = new UltracemDB();
        }

        /// <summary>
        /// Meotodo utilizado para guardar en la tabla de log
        /// </summary>
        /// <param name="logBancoSiesa"></param>
        /// <returns></returns>
        public async Task<LogBancoSiesa> Add(LogBancoSiesa logBancoSiesa)
        {
            try
            {
                db = new UltracemDB();
                db.LogBancoSiesa.Add(logBancoSiesa);
                await db.SaveChangesAsync();

                return logBancoSiesa;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            
        }
    }
}
