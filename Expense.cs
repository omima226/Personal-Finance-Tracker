using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker
{
    public class Expense
    {
        public Expense(decimal amount, string category)
        {
            Amount = amount;
            Category = category;
        }

        public decimal Amount { get; }
        public string Category { get; }

        public override string ToString()
        {
            return $"Amount : {Amount:C} , Category : {Category}";
        }
    }
}
