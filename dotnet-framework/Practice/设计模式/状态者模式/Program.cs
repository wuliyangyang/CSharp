using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 状态者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account("shanpao");
            account.Deposit(1000);
            account.Deposit(1000);

            account.PayInterest();
            account.Withdraw(2000);

            account.Deposit(1000000);
            account.PayInterest();

            Console.ReadKey();
        }
    }

    class Account
    {
        public State State { get; set; }
        public string Owner { get; set; }

        public double Balance { get { return State.Balance; } }
        public Account(string owner)
        {
            this.Owner = owner;
            this.State = new SilverState(100, this);
            
        }


        public void Deposit(double amount)
        {
            Console.WriteLine("当前余额:{0:C}", Balance);
            State.Deposit(amount);
            Console.WriteLine("存款金额:{0:C}", amount);
            Console.WriteLine("总余额:{0:C}", Balance);
            Console.WriteLine("账户状态:{0}", State.GetType().Name);
            Console.WriteLine();
        }
        public void Withdraw(double amount)
        {
            Console.WriteLine("当前余额:{0:C}", Balance);
            State.Withdraw(amount);
            Console.WriteLine("取款金额:{0:C}", amount);
            Console.WriteLine("总余额:{0:C}", Balance);
            Console.WriteLine("账户状态:{0}", State.GetType().Name);
            Console.WriteLine();
        }
        public void PayInterest()
        {
            Console.WriteLine("账户状态{0}", State.GetType().Name);
            Console.WriteLine("获取利息,利率为{0}",State.Interest);
            Console.WriteLine("总余额:{0:C}", Balance);
            Console.WriteLine();
        }
    }
    abstract class State
    {
        public Account Account { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
        public double UpperLimit { get; set; }
        public double LowerLimit { get; set; }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();

    }

    class SilverState : State
    {
        public SilverState(State state) : this(state.Balance, state.Account)
        {

        }
        public SilverState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            UpperLimit = 1000;
            LowerLimit = 0;
            Interest = 0;
        }

        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChange();
        }

        public override void PayInterest()
        {
            Balance += Balance * Interest;
            StateChange();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChange();
        }

        private void StateChange()
        {
            if (Balance < LowerLimit)
            {
                Account.State = new RedState(this);
            }
            else if (Balance > UpperLimit)
            {
                Account.State = new GoldState(this);
            }
        }
    }
    class RedState : State
    {
        public RedState(State state) : this(state.Balance, state.Account)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            UpperLimit = 0;
            LowerLimit = -100;
            Interest = 0;
        }
        public RedState(double balance, Account account)
        {
            this.Balance = balance;
            this.Account = account;
            UpperLimit = 0;
            LowerLimit = -100;
            Interest = 0;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChange();
        }

        public override void PayInterest()
        {

        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("没钱可以取了");
        }
        private void StateChange()
        {
            if (Balance > UpperLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }

    class GoldState : State
    {
        public GoldState(State state)
        {
            this.Balance = state.Balance;
            this.Account = state.Account;
            UpperLimit = 100000;
            LowerLimit = 1000;
            Interest = 0.005;
        }
        public override void Deposit(double amount)
        {
            Balance += amount;
            StateChange();
        }

        public override void PayInterest()
        {
            Balance += Balance * Interest;
            StateChange();
        }

        public override void Withdraw(double amount)
        {
            Balance -= amount;
            StateChange();
        }

        private void StateChange()
        {
            if (Balance < 0.0)
            {
                Account.State = new RedState(this);
            }
            else if (Balance < LowerLimit)
            {
                Account.State = new SilverState(this);
            }
        }
    }
}
