namespace one.hr.api.Services
{
    public interface IAccountNumberValidationService
    {
        bool IsValid(string accountNumber);
    }
}
