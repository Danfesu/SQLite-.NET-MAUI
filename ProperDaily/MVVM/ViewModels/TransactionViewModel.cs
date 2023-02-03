using ProperDaily.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperDaily.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class TransactionViewModel
    {
        public Transaction Transaction { get; set; } = new Transaction();

        public string SaveTransaction()
        {
            App.TransactionRepo.SaveItem(Transaction);
            return App.TransactionRepo.StatusMessage;
        }
    }
}
