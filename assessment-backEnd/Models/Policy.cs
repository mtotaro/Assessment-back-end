using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Policies
    {
        public List<Policy> policies { get; set; }
    }
    
    public class Policy
    {
        public Guid Id { get; set; }
        public double AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
