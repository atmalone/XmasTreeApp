using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XmasTreeApplication.Data.Entities;

namespace XmasTreeApplication.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [MinLength(4)]
        public string OrderNumber { get; set; }
        public Customer Customer{ get; set; }
    }
}