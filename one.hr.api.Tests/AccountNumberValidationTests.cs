using one.hr.api.Services;

namespace one.hr.api.Tests
{
    public class AccountNumberValidationTests
    {
        private readonly AccountNumberValidation _validationSvc;
        public AccountNumberValidationTests()=>_validationSvc = new AccountNumberValidation();
        [Fact]
        public void IsValid_AccountNumber_ReturnsTrue()
        {
            Assert.True(_validationSvc.IsValid("123-1234567890-12"));
        }
    }
}