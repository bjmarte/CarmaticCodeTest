using CarmaticCode;

namespace CarmaticTests
{
    public class AccountTests
    {
        private Account _account;

        [SetUp]
        public void Setup()
        {
            _account = new Account("Brandon Etchison", 200, "Individual Savings", 1000);
        }

        [Test]
        public void AccountCreation_BalanceEqualsInitialBalance()
        {
            var initialBalance = 1274.25m;
            var createdAccount = new Account("Whatever", initialBalance, "doesn't matter", 0);

            Assert.That(createdAccount.Balance, Is.EqualTo(initialBalance));
        }

        [Test]
        public void AccountDeposit_IncreasesBalanceByAmount()
        {
            var initialBalance = _account.Balance;
            var depositAmount = 333.33m;
            _account.Deposit(depositAmount);
            
            Assert.That(_account.Balance, Is.EqualTo(initialBalance + depositAmount));
        }

        [Test]
        public void AccountDeposit_AmountMustBeGreaterThanZero()
        {
            
        }

        [Test]
        public void AccountWithdrawal_DecreaseBalanceByAmount()
        {
            var initialBalance = _account.Balance;
            var withdrawalAmount = 42.75m;
            _account.Withdraw(withdrawalAmount);

            Assert.That(_account.Balance, Is.EqualTo(initialBalance - withdrawalAmount));
        }

        [Test]
        public void AccountWithdrawal_FailsIfAboveWithdrawalLimit()
        {
            Assert.Throws<ArgumentException>(() => _account.Withdraw(1000.01m), "Withdrawal limit exceeded");
        }

        [Test]
        public void AccountWithdrawal_DoesNotFailWhenWithdrawalLimitZero()
        {
            var noWithdrawalLimitAccount = new Account("someone", 1200, "Another checking account", 0);

            noWithdrawalLimitAccount.Withdraw(1200);

            Assert.That(noWithdrawalLimitAccount.Balance, Is.Zero);
        }

        [Test]
        public void AccountWithdrawal_AmountMustBeGreaterThanZero()
        {
            
        }

        [Test]
        public void AccountWithdrawal_FailsIfInsufficientFunds()
        {
            
        }

        [Test]
        public void AccountTransfer_DecreaseBalanceByAmount_IncreaseDestinationBalanceBySameAmount()
        {
            var destinationAccount = new Account("someone", 6725.11m, "Individual Checking", 1000m);

            var sourceInitialBalance = _account.Balance;
            var destinationInitialBalance = destinationAccount.Balance;

            var transferAmount = 73.22m;

            _account.Transfer(transferAmount, destinationAccount);

            Assert.That(_account.Balance, Is.EqualTo(sourceInitialBalance - transferAmount));
            Assert.That(destinationAccount.Balance, Is.EqualTo(destinationInitialBalance + transferAmount));
        }

        [Test]
        public void AccountTransfer_FailsIfInsufficientFunds()
        {
            // Requirements question here
        }

        [Test]
        public void AccountTransfer_FailsIfAboveWithdrawalLimit()
        {
            // Requirements question here
        }

        [Test]
        public void AccountTransfer_AmountMustBeGreaterThanZero()
        {
            
        }

        [Test]
        public void AccountTransfer_AccountsMustHaveSameOwner()
        {
            
        }
    }
}