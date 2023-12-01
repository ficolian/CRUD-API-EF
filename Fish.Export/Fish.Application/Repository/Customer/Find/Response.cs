using System;
using System.Collections.Generic;
using System.Text;

namespace Fish.Application.Usecase
{
    public class FindCustomerData
    {
        public string customerId { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string createdBy { get; set; }
        public DateTime createdAt { get; set; }
        public string modifiedBy { get; set; }
        public DateTime modifiedOn { get; set; }
    }
}
