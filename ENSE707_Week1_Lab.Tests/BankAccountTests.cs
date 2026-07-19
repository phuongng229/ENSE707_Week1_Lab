using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;

namespace ENSE707_Week1_Lab.Tests;
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

    [TestMethod]
    public void OpeningBalance_NegativeAmount_ThrowsArgumentException()
    {
        // Assert
        Assert.ThrowsException<ArgumentException>(() => new BankAccount("Test User", -1));
    }

    [TestMethod]
    public void AccountHolderName_NullOrEmpty_ThrowsArgumentException()
    {
        Assert.ThrowsException<ArgumentException>(() => new BankAccount("", 100));
        Assert.ThrowsException<ArgumentException>(() => new BankAccount(null, 50));
    }

    [TestMethod]
    public void Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        BankAccount account = new BankAccount("Test User", 200);

        // Assert
        Assert.ThrowsException<ArgumentException>(() => account.Deposit(-50));
    }

    [TestMethod]
    public void Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        BankAccount account = new BankAccount("Test User", 200);

        // Assert
        Assert.ThrowsException<ArgumentException>(() => account.Withdraw(-50));
    }

    [TestMethod]
    public void Withdraw_AmountGreaterThanBalance_DoesNotChangeBalance()
    {
        BankAccount account = new BankAccount("Test User", 200);

        Assert.IsFalse(account.Withdraw(300));
        Assert.AreEqual(200, account.Balance);
    }

}