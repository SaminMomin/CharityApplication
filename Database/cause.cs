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
    using CharityApplication.Models;
    using System;
    using System.Collections.Generic;
    
    public partial class cause:BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cause()
        {
            this.donations = new HashSet<donation>();
        }
    
        public string name { get; set; }
        public int goal { get; set; }
        public int collected { get; set; }
        public int orgId { get; set; }
        public Nullable<int> hash { get; set; }
        public bool isactive { get; set; }
        public string description { get; set; }
        public string transactionhash { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donation> donations { get; set; }
        public virtual organization organization { get; set; }
    }
}
