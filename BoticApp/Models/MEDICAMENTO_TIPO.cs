//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BoticApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MEDICAMENTO_TIPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MEDICAMENTO_TIPO()
        {
            this.MEDICAMENTO = new HashSet<MEDICAMENTO>();
        }
    
        public decimal ID_MEDICAMENTO_TIPO { get; set; }
        public string MEDICAMENTO_TIPO1 { get; set; }
        public string DESCRIPCION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MEDICAMENTO> MEDICAMENTO { get; set; }
    }
}