//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gambit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Info()
        {
            this.Kontakt = new HashSet<Kontakt>();
        }
    
        public Nullable<System.DateTime> dzienImienin { get; set; }
        public Nullable<System.DateTime> dataUrodzenia { get; set; }
        public int infoId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kontakt> Kontakt { get; set; }
    }
}
