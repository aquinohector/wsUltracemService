//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cw.Ultracem.Data.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BancosWS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BancosWS()
        {
            this.LogBancoSiesa = new HashSet<LogBancoSiesa>();
        }
    
        public decimal Id { get; set; }
        public string NombreBanco { get; set; }
        public byte[] Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LogBancoSiesa> LogBancoSiesa { get; set; }
    }
}