namespace one.hr.api.Services
{
    public class AccountNumberValidation : IAccountNumberValidationService
    {
        private const int StartingPartLength = 3;
        private const int MiddlePartLength = 10;
        private const int EndingPartLength = 2;
        public bool IsValid(string accountNumber)
        {
            var firstDelimiter = accountNumber.IndexOf('-');
            var secondDelimiter = accountNumber.LastIndexOf('-');
            if (firstDelimiter == -1 || secondDelimiter == -1)
                throw new ArgumentException();
            var firstPart = accountNumber.Substring(0, firstDelimiter);
            if(firstPart.Length != StartingPartLength)
                return false;
            var tempPart = accountNumber.Remove(0, StartingPartLength+1);
            var middlePart = tempPart.Substring(0 , tempPart.IndexOf('-'));
            if(middlePart.Length!= MiddlePartLength) return false;

            var lastPart = accountNumber.Substring(secondDelimiter+1);
            if(lastPart.Length!= EndingPartLength) return false;
            return true;
        }
    }
}
