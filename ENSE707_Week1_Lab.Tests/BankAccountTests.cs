using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;

namespace ENSE707_Week1_Lab_Tests;
[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount("Test User", 100);

        // Act
        account.Deposit(50);

        // Assert
        Assert.AreEqual(150, account.Balance);
    }

    [TestMethod]
    public void Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        BankAccount account = new BankAccount("Test User", 100);

        bool result = account.Withdraw(40);

        Assert.IsTrue(result);

        // Assert
        Assert.AreEqual(60, account.Balance);
    }

    [TestMethod]
    public void Withdraw_AmountGreaterThanBalance_ReturnsFalse()
    {
        // Arrange
        BankAccount account = new BankAccount("Test User", 100);

        // Act
        bool result = account.Withdraw(300);

        // Assert
        Assert.IsFalse(result);
    }
}