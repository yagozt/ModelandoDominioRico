using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

using Xunit;

namespace PaymentContext.Tests.ValueObjects
{
    public class DocumentTests
    {
        // Red, Green, Refactor
        [Fact]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.True(doc.Invalid);
        }

        [Fact]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.True(doc.Invalid);
        }

        [Fact]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("96190961000185", EDocumentType.CNPJ);
            Assert.True(doc.Valid);
        }

        [Theory]
        [InlineData("93764699337")]
        [InlineData("77838445612")]
        [InlineData("10895387239")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.True(doc.Valid);
        }
    }
}
