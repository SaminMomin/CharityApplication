//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CharityApplication.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class cause
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cause()
        {
            this.donations = new HashSet<donation>();
        }
    
        public int Id { get; set; }
        public string name { get; set; }
        public decimal goal { get; set; }
        public decimal collected { get; set; }
        public int orgId { get; set; }
        public string hash { get; set; }
    
        public virtual organization organization { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donation> donations { get; set; }
    }
}
