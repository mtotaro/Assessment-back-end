﻿using System;

namespace DTO
{
    public class PoliciesDTO
    {
        public Guid Id { get; set; }
        public double AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public Guid ClientId { get; set; }
    }
}
