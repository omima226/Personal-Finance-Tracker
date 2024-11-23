using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker
{
    public class Income
    {
        public Income(decimal amount, string source)
        {
            Amount = amount;
            Source = source;
        }

        public decimal Amount { get; }
        public string Source { get; }

        public override string ToString()
        {
            return $"Amount : {Amount:C}, Source : {Source}";
        }
    }
}
