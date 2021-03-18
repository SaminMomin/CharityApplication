using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharityApplication.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public BaseEntity()
        {
            Id= Guid.NewGuid().GetHashCode() & 0xfffffff;
        }

    }
}