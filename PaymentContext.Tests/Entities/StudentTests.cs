using System;

using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

using Xunit;

namespace PaymentContext.Tests
{
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Name _name;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Document _document;

        public StudentTests()
        {
            _name = new Name("Clack", "Kent");
            _document = new Document("93764699337", Domain.Enums.EDocumentType.CPF);
            _email = new Email("superman@gmail.com");
            _address = new Address("Rua 1", "2134", "Gothan", "Serra", "ES", "Brasil", "29166510");

            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);

        }

        [Fact]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PayPalPayment("12345678", _email, DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Payer", _document, _address);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnErrorWhenHadSubscriptionHasNoPayment()
        {
            _student.AddSubscription(_subscription);

            Assert.True(_student.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PayPalPayment("12345678", _email, DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Payer", _document, _address);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.True(_student.Valid);
        }
    }
}
