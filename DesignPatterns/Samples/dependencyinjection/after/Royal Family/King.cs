using System;

namespace DI.After
{
    public class King : IKing
    {
        private readonly IFinancier _financierManager;
        private string _name;
        private int _age;

        public King(IFinancier financierManager)
        {
            _financierManager = financierManager;
        }

        public King(IFinancier financierManager, string name) //: this(financierManager)
        {
            _financierManager = financierManager;
            _name = name;
        }

        public King(IFinancier financierManager, string name, int age) //: this(financierManager, name)
        {
            _financierManager = financierManager;
            _name = name;
            _age = age;
        }

        public King(IFinancier financierManager, ID id) //: this(financierManager, id.Name, id.Age)
        {
            _financierManager = financierManager;
            _name = id.Name;
            _age = id.Age;

            Console.WriteLine("Received an ID");
        }

      
        public void RuleTheCastle()
        {
            Console.WriteLine("King: " + _name);
            _financierManager.CollectTaxes();
        }



    }

    public class ID
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}