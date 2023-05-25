namespace CarmaticCode;

public class Account
{
    private readonly decimal _maxWithdrawal;
    public string Owner { get; }
    public decimal Balance { get; private set; }
    public string Description { get; }

    public Account(string owner, decimal balance, string description, decimal maxWithdrawal)
    {
        _maxWithdrawal = maxWithdrawal;
        Owner = owner;
        Balance = balance;
        Description = description;
    }

    public void Deposit(decimal depositAmount)
    {
        Balance += depositAmount;
    }

    public void Withdraw(decimal withdrawalAmount)
    {
        if (_maxWithdrawal > 0 && withdrawalAmount > _maxWithdrawal)
        {
            throw new ArgumentException("Withdrawal limit exceeded");
        }

        Balance -= withdrawalAmount;
    }

    public void Transfer(decimal transferAmount, Account destinationAccount)
    {
        Withdraw(transferAmount);
        destinationAccount.Deposit(transferAmount);
    }
}