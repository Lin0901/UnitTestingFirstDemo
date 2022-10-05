namespace BankUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public BankAccount TestAccount { get; set; }
        public decimal InitialBalance { get; set; }
        public UnitTest1()
        {
            InitialBalance = 500; //��ʼ��� 500Ԫ
            TestAccount = new BankAccount(); 
            TestAccount.balance = InitialBalance;
        }

        //Withdraw method should subtract the amount withdraw from the balance of the Account

        [TestMethod]
        public void AccountWithdraw_SubtractsFromBalance() //�˻�ȡ��_������м�ȥ  ����
        { 

            // Arranges ����
            decimal withdrawlAmount = 200.5m;  //ȡ�� 200.5
            decimal assertedBalance = InitialBalance - withdrawlAmount; //���̺�����

            // Act ��Ϊ
            TestAccount.Withdraw(withdrawlAmount); //���� Program����ķ�����if���

            // Assert ���ϣ����
            Assert.AreEqual(assertedBalance, TestAccount.balance);  // Assert��������һ����������һ��������бȽ� ���ڴ��ģ�ʵ�ʵģ�
        }

        [TestMethod]
        public void AccountWithdraw_throwsExceptionWhenArgumentGreaterThanBalance() //�˻�ȡ��_����������ƽ��ʱ�׳��쳣  ����
        {
            // Arrange
            decimal currantBalance = 500;  //Ŀǰ 500
            BankAccount account = new BankAccount();  //������Program�йص� ����� account �ؼ���
            account.balance = currantBalance;  //���µ�����ؼ��� ���� 500

            decimal withdrawlAmount = 700; //ȡ�� 700

            // act and assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                TestAccount.Withdraw(withdrawlAmount);     //Assert.ThrowsException �ж϶����쳣
            });
        }

        [TestMethod]
        public void AccountDeposit_AddToBalance() // �˻����_��ӵ����
        {
            // arrange
            decimal depositAmount = 125.32m;   // ��� 125.32
            decimal assertedBalance = depositAmount + InitialBalance;  // asserted = ��� + ���ڡ�

            // act
            TestAccount.Deposit(depositAmount);  // �½��� �ڶ��� Program ����

            //assert
            Assert.AreEqual(assertedBalance, TestAccount.balance);  // Assert��������һ����������һ��������бȽ� ���ڴ��ģ�ʵ�ʵģ�
        }

        [TestMethod]
        public void AccountDeposit_ThrowExceptionOnZeroOrNegativeAmount()  //�ʻ����_�׳� "��������쳣"��
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