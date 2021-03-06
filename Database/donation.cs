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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class donation: BaseEntity
    {
        //public int Id { get; set; }
        public int userId { get; set; }
        public int orgId { get; set; }
        [DisplayName("Amount")]
        [Required]
        public int amount { get; set; }
        public int causeId { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [Required]
        public System.DateTime date { get; set; }
        public string transactionhash { get; set; }
    
        public virtual cause cause { get; set; }
        public virtual organization organization { get; set; }
        public virtual user user { get; set; }
    }
}
