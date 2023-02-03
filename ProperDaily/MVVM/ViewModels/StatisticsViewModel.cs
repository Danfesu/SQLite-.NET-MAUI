using ProperDaily.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsViewModel
    {
        public ObservableCollection<TransactionsSummary> Summary { get; set; }
        public ObservableCollection<Transaction> SpendingList { get; set; }

        public void GetTransactionsSummary()
        {
            var data =
                App.TransactionRepo.GetItems();
            var result = new List<TransactionsSummary>();
            var groupedTransactions = data.GroupBy(x => x.OperationDate.Date);

            foreach (var group in groupedTransactions)
            {
                var transactionsSummary = new TransactionsSummary
                {
                    TransactionsDate = group.Key,
                    TransactionsTotal = group.Sum(x=>x.IsIncome?x.Amount:-x.Amount),
                    ShownDate = group.Key.ToString("MM/dd"),
                };
                result.Add(transactionsSummary);
            }

            result = result.OrderBy(x => x.TransactionsDate).ToList();

            Summary = new ObservableCollection<TransactionsSummary>(result);

            var spendingList = data.Where(x => x.IsIncome == false);

            SpendingList = new ObservableCollection<Transaction>(spendingList);
        }

    }
}
