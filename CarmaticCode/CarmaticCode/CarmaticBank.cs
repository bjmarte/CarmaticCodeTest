namespace CarmaticCode
{
    public class CarmaticBank
    {
        readonly List<Account> _accounts = new List<Account>();
        public CarmaticBank(string name)
        {
            Name = name;
        }
        
        public string Name { get; }

        public void AddSavingsAccount(string owner, decimal openingBalance)
        {
            _accounts.Add(new Account(owner, openingBalance, "Savings Account", 0));
        }

        public void AddCheckingAccount(string owner, decimal openingBalance, CheckingType checkingType)
        {
            var maxWithdrawal = checkingType == CheckingType.Individual ? 1000 : 0;
            _accounts.Add(new Account(owner, openingBalance, $"{Enum.GetName(checkingType)} Checking Account", maxWithdrawal));
        }

    }

    public enum CheckingType
    {
        Individual,
        MoneyMarket
    }

}