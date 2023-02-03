using ProperDaily.MVVM.Models;
using ProperDaily.MVVM.Views;
using ProperDaily.Repositories;

namespace ProperDaily;

public partial class App : Application
{
	public static BaseRepository<Transaction> TransactionRepo { get; private set; }
	public App(BaseRepository<Transaction> _transactionRepo)
	{
		InitializeComponent();

		TransactionRepo = _transactionRepo;

		MainPage = new AppContainer();
	}
}
