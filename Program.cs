namespace Personal_Finance_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FinanceTracker tracker = new FinanceTracker();
            tracker.LoadData();

            while (true)
            {
                Console.WriteLine("\nPersonal Finance Tracker");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Expenses");
                Console.WriteLine("5. Set Budget");
                Console.WriteLine("6. View Budget Status");
                Console.WriteLine("7. Generate Report");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        tracker.AddIncome();
                        break;
                    case "2":
                        tracker.AddExpense();
                        break;
                    case "3":
                        tracker.ViewIncome();
                        break;
                    case "4":
                        tracker.ViewExpenses();
                        break;
                    case "5":
                        tracker.SetBudget();
                        break;
                    case "6":
                        tracker.ViewBudgetStatus();
                        break;
                    case "7":
                        tracker.GenerateReport();
                        break;
                    case "8":
                        tracker.SaveData();
                        return;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }
    }
}
