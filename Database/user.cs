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
    
    public partial class user: BaseEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.donations = new HashSet<donation>();
        }
    
        //public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public string password { get; set; }
        public System.DateTime dob { get; set; }
        public string contact { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public Nullable<int> hash { get; set; }
        public string transactionhash { get; set; }
        public string profilepic { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<donation> donations { get; set; }
    }
}
