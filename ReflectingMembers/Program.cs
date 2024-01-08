
using System.Reflection;

namespace ReflectingMembers
{
    internal class Program
    {

        static void Main(string[] args)
        {

            #region Recap on events and how to firing them
            //BankAccount account = new BankAccount("ff0", "abdullah" , 1000);
            //account.onNegativeBalance += Account_onNegativeBalance;
            //account.Withdraw(500);
            //account.Withdraw(600);
            //Console.WriteLine(account);
            #endregion


            #region Reflecting members 

            //MemberInfo[] members = typeof(BankAccount).GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

            //Console.WriteLine("Member Info");
            //foreach (var member in members)
            //{
            //    Console.WriteLine(member);
            //}


            //FieldInfo []fields  = typeof(BankAccount).GetFields(BindingFlags.Static | BindingFlags.NonPublic| BindingFlags.Public);
            //Console.WriteLine("Field Info");
            //foreach (var field in fields)
            //{
            //    Console.WriteLine(field);
            //}

            //PropertyInfo[] Properties = typeof(BankAccount).GetProperties();
            //Console.WriteLine("Property Info");
            //foreach (var prperty in Properties)
            //{
            //    Console.WriteLine(prperty.GetGetMethod());
            //    Console.WriteLine(prperty);
            //}

            //EventInfo[] Events= typeof(BankAccount).GetEvents();
            //Console.WriteLine("Events Info");
            //foreach (var e in Events)
            //{

            //    Console.WriteLine(e);
            //}


            //ConstructorInfo[] constructors = typeof(BankAccount).GetConstructors();
            //Console.WriteLine("Constructor Info");

            //foreach(var constructor in constructors)
            //    Console.WriteLine(constructor);
            #endregion


            #region Reflecting Assemblies 

            var path = "C:\\Users\\3resha\\Desktop";

            var path_01 = @"C:\Users\3resha\Desktop";

            var assembly = Assembly.LoadFile(path_01);
            var types = assembly.GetTypes();

            foreach(var t in types)
                Console.WriteLine(t);

            #endregion 


        }

        private static void Account_onNegativeBalance(object? sender, EventArgs e)
        {
            var a = (BankAccount)sender;
            Console.WriteLine("Negative Balance");
            //Console.WriteLine(a);
        }
    }


    class BankAccount
    {
        private string accountNo;
        private string holder;
        private decimal balance;

        public BankAccount(string accountNo, string holder, decimal balance)
        {
            this.accountNo = accountNo;
            this.holder = holder;
            this.balance = balance;
        }

        public event EventHandler onNegativeBalance; 
        public string AccountNo => accountNo; 
        public string Holder => holder; 
        public decimal Balance=> balance;

        
        public decimal Deposite(decimal cost)
        {
            return balance += cost;
        }


        public decimal Withdraw (decimal cost)
        {
            balance -= cost;
            if (balance < 0)
            {
                this.onNegativeBalance.Invoke(this, null);
            }
            return balance ;
        }
        public override string ToString()
        {
            return $"{{Account No: {accountNo}, Holder: {holder}, Balance: ${balance}}}";
        }
    }
}