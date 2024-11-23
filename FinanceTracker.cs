using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker
{
    internal class FinanceTracker
    {
        private List<Income> incomes = new List<Income>();
        private List<Expense> expenses = new List<Expense>();
        private decimal budgetLimit = 0;

        public void AddIncome()
        {
            decimal amount;
            string source;
            Console.WriteLine("Enter Income Amount : ");
            while (!decimal.TryParse(Console.ReadLine(),out amount)|| amount <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for income");
            }
            Console.WriteLine("Enter Income Source");
            source = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(source))
            {
                Console.WriteLine("Source can't be empty");
                return;
            }
            incomes.Add(new Income(amount, source));
            Console.WriteLine("Income added successfully!");
        }
        public void AddExpense()
        {
            decimal amount;
            string category;
            Console.WriteLine("Enter Expense Amount :");
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for Expense");
            }
            category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Source can't be empty");
                return;
            }
            expenses.Add(new Expense(amount, category));
        }
        public void ViewIncome()
        {
            Console.WriteLine("Expense Entries:");
            foreach (var income in incomes)
            {
                Console.WriteLine(income);
            }
        }
        public void ViewExpenses()
        {
            Console.WriteLine("Expense Entries:");
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }
        public void SetBudget()
        {
            Console.WriteLine("Enter budget limit:");
            while (!decimal.TryParse(Console.ReadLine(), out budgetLimit) || budgetLimit < 0)
            {
                Console.WriteLine("Please enter a valid non-negative number for the budget.");
            }
            Console.WriteLine($"Budget set to {budgetLimit:C}");
        }
        public void ViewBudgetStatus()
        {
            decimal totalExpenses = expenses.Sum(e => e.Amount);
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine(totalExpenses > budgetLimit ? "You have exceeded your budget!" : "You are within your budget.");
        }
        public void GenerateReport()
        {
            decimal totalIncome = incomes.Sum(i => i.Amount);
            decimal totalExpenses = expenses.Sum(e => e.Amount);
            decimal netBalance = totalIncome - totalExpenses;

            Console.WriteLine("Financial Report:");
            Console.WriteLine($"Total Income: {totalIncome:C}");
            Console.WriteLine($"Total Expenses: {totalExpenses:C}");
            Console.WriteLine($"Net Balance: {netBalance:C}");
        }
        public void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("finance_data.txt"))
            {
                foreach (var income in incomes)
                {
                    writer.WriteLine($"Income,{income.Amount},{income.Source}");
                }

                foreach (var expense in expenses)
                {
                    writer.WriteLine($"Expense,{expense.Amount},{expense.Category}");
                }

                writer.WriteLine($"Budget,{budgetLimit}");
            }
            Console.WriteLine("Data saved successfully!");
        }
        public void LoadData()
        {
            if (File.Exists("finance_data.txt"))
            {
                foreach (var line in File.ReadLines("finance_data.txt"))
                {
                    var parts = line.Split(',');
                    switch (parts[0])
                    {
                        case "Income":
                            incomes.Add(new Income(decimal.Parse(parts[1]), parts[2]));
                            break;
                        case "Expense":
                            expenses.Add(new Expense(decimal.Parse(parts[1]), parts[2]));
                            break;
                        case "Budget":
                            budgetLimit = decimal.Parse(parts[1]);
                            break;
                    }
                }
                Console.WriteLine("Data loaded successfully!");
            }
        }
    }

}
