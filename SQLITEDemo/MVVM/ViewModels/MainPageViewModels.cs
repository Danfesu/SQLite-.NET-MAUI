using Bogus;
using PropertyChanged;
using SQLITEDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLITEDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModels
    {
        public List<Customer> Customers { get; set; }
        public Customer CurrentCustomer { get; set; }

        public ICommand AddOrUpdateCommand {get; set;}
        public ICommand DeleteCommand { get; set;}

        public MainPageViewModels() 
        {
            var orders =
                App.OrderRepo.GetItems();

            Refresh();
            GenerateNewCustomer();

            AddOrUpdateCommand = new Command(() =>
            {
                //App.CustomerRepo.SaveItem(CurrentCustomer);
                App.CustomerRepo.SaveItemWithChildren(CurrentCustomer);
                Console.WriteLine(App.CustomerRepo.StatusMessage);
                GenerateNewCustomer();
                Refresh();
            });

            DeleteCommand = new Command(() =>
            {
                App.CustomerRepo.DeleteItem(CurrentCustomer);
                Refresh();
            });
        }

        private void GenerateNewCustomer()
        {
            CurrentCustomer = new Faker<Customer>()
                .RuleFor(x => x.Name, f => f.Person.FullName)
                .RuleFor(x => x.Address, f => f.Person.Address.Street)
                .Generate();

            CurrentCustomer.Passport = new List<Passport>
            {
                new Passport
                {
                    ExpirationDATE = DateTime.Now.AddDays(30)
                },
                new Passport
                {
                    ExpirationDATE = DateTime.Now.AddDays(15)
                }
            };
        }

        private void Refresh()
        {
            //Customers = App.CustomerRepo.GetAll();
            //Customers = App.CustomerRepo.GetItems(x => x.Name.StartsWith("A"));
            //Customers = App.CustomerRepo.GetItems();
            Customers = App.CustomerRepo.GetItemsWithChildren();
            var passports =
                App.PassportRepo.GetItems();
        }
    }
}
