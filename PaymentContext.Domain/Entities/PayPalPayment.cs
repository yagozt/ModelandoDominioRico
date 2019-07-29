using System;

using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode,
            Email email,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address) : base(paidDate, expireDate, total, totalPaid, payer, document, address)
        {
            TransactionCode = transactionCode;
            Email = email;
        }

        public string TransactionCode { get; private set; }
        public Email Email { get; private set; }
    }
}
