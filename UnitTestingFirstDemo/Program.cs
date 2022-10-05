Console.WriteLine("Run");
public class BankAccount 
{
    // balance 余额
    // withdrawl 取款
    private decimal _balance;
    public decimal balance
    {
        get { return _balance; }
        set { _balance = value; }
    }

    public void Withdraw(decimal amount)
    {
        if(balance >= amount)
        {
            balance -= amount;
        }
        else
        {   // ArgumentException 参数异常
            //ArgumentException是一个自定义“合法参数”的异常，ArgumentException类所接受的合法参数，是由程序员自行设置的。 FormatException当参数格式不符合调用的方法的参数规范时引发的异常. 虽然说是“方法的参数”，但是其实包含了绝大多数的格式异常，例如：索引的格式异常等等。
            throw new ArgumentException("Withdraw exceeds available funds.");
        }
    }

    // To be implemented 有待实施
    public decimal Deposit(decimal amount)
    {
        if (amount > 0)   // 如果存款 > 0  就能存
        {
            balance += amount;

            return balance;
        }
        else // 存款 <= 0 就告诉你是穷比
        {
            throw new ArgumentException("Amount need more than");
        }

    }

    public decimal GetBalance()
    {
        return balance;
    }

    public decimal CalculatePercentage(decimal percentage)
    {
        return 0;
    }

}
