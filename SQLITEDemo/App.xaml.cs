using SQLITEDemo.MVVM.Models;
using SQLITEDemo.MVVM.Views;
using SQLITEDemo.Repositories;

namespace SQLITEDemo;

public partial class App : Application
{
	//public static CustomerRepository CustomerRepo { get; private set; }
	// Singleton a CustomerRepository en MainProgram.cs
	public static BaseRepository<Customer> CustomerRepo { get; private set; }
    public static BaseRepository<Order> OrderRepo { get; private set; }
    public static BaseRepository<Passport> PassportRepo { get; private set; }


    public App(BaseRepository<Customer> repo, BaseRepository<Order> orderRepo, BaseRepository<Passport> passportRepo)
	{
		InitializeComponent();

		CustomerRepo = repo;
		OrderRepo = orderRepo;
		PassportRepo = passportRepo;

		MainPage = new MainPage();
	}
}
