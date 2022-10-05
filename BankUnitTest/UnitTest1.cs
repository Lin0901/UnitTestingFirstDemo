namespace BankUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public BankAccount TestAccount { get; set; }
        public decimal InitialBalance { get; set; }
        public UnitTest1()
        {
            InitialBalance = 500; //初始余额 500元
            TestAccount = new BankAccount(); 
            TestAccount.balance = InitialBalance;
        }

        //Withdraw method should subtract the amount withdraw from the balance of the Account

        [TestMethod]
        public void AccountWithdraw_SubtractsFromBalance() //账户取款_从余额中减去  方法
        { 

            // Arranges 布置
            decimal withdrawlAmount = 200.5m;  //取款 200.5
            decimal assertedBalance = InitialBalance - withdrawlAmount; //过程后的余额

            // Act 行为
            TestAccount.Withdraw(withdrawlAmount); //测试 Program里面的方法，if语句

            // Assert 决断，最后
            Assert.AreEqual(assertedBalance, TestAccount.balance);  // Assert方法：将一个对象与另一个对象进行比较 （期待的，实际的）
        }

        [TestMethod]
        public void AccountWithdraw_throwsExceptionWhenArgumentGreaterThanBalance() //账户取款_当参数大于平衡时抛出异常  方法
        {
            // Arrange
            decimal currantBalance = 500;  //目前 500
            BankAccount account = new BankAccount();  //还是与Program有关的 新设的 account 关键字
            account.balance = currantBalance;  //让新的这个关键字 等于 500

            decimal withdrawlAmount = 700; //取款 700

            // act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TestAccount.Withdraw(withdrawlAmount);     //Assert.ThrowsException 判断断言异常
            });
        }

        [TestMethod]
        public void AccountDeposit_AddToBalance() // 账户存款_添加到余额
        {
            // arrange
            decimal depositAmount = 125.32m;   // 存款 125.32
            decimal assertedBalance = depositAmount + InitialBalance;  // asserted = 存款 + 现在。

            // act
            TestAccount.Deposit(depositAmount);  // 新建的 第二个 Program 里面

            //assert
            Assert.AreEqual(assertedBalance, TestAccount.balance);  // Assert方法：将一个对象与另一个对象进行比较 （期待的，实际的）
        }

        [TestMethod]
        public void AccountDeposit_ThrowExceptionOnZeroOrNegativeAmount()  //帐户存款_抛出 "零或负数的异常"。
        {
            // arrange
            decimal firstDepositAmount = 0;
            decimal secondDepositAmount = -3m;

            //act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TestAccount.Deposit(firstDepositAmount);
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                TestAccount.Deposit(secondDepositAmount);
            });
        }
    }
}