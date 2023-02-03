using ProperDaily.MVVM.ViewModels;

namespace ProperDaily.MVVM.Views;

public partial class StatisticsPage : ContentPage
{
	public StatisticsPage()
	{
		InitializeComponent();

		BindingContext = new StatisticsViewModel();
	}

    protected override void OnAppearing()
    {
        var vm = (StatisticsViewModel) BindingContext;
		vm.GetTransactionsSummary();
    }
}