//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcFirmaCagri.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDepartmanlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDepartmanlar()
        {
            this.tblPersonel = new HashSet<tblPersonel>();
        }
    
        public int ID { get; set; }
        public string Ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPersonel> tblPersonel { get; set; }
    }
}
