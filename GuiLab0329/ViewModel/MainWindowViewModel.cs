using GuiLab0329.Logic;
using GuiLab0329.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GuiLab0329.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {

        IMenuLogic logic;


        public ObservableCollection<Food> leftList { get; set; }
        public ObservableCollection<Food> rightList { get; set; }
        public ObservableCollection<Food> filteredList { get; set; }
        public ObservableCollection<typeOfFood> filterTypes { get; set; }
        public typeOfFood selectedFilter { get; set; }
        public bool check { get; set; }

        private Food selectedFromLeft;

        public Food SelectedFromLeft
        {
            get { return selectedFromLeft; }
            set
            {
                SetProperty(ref selectedFromLeft, value);
                (AddToRight as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        private Food selectedFromRight;

        public Food SelectedFromRight
        {
            get { return selectedFromRight; }
            set
            {
               SetProperty(ref selectedFromRight, value);
                (RemoveFromRight as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public int AllCost
        { get { return logic.AllCost; } }

        public ICommand AddToRight { get; set; }
        public ICommand RemoveFromRight { get; set; }
        public ICommand Checked { get; set; }


        public static bool IsInDesignMode
        {

            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IMenuLogic>())
        {

        }

        public MainWindowViewModel(IMenuLogic logic)
        {
            this.logic = logic;

            leftList = new ObservableCollection<Food>();
            filteredList = new ObservableCollection<Food>();
            filterTypes = new ObservableCollection<typeOfFood>();
            rightList = new ObservableCollection<Food>();

            filterTypes.Add(typeOfFood.maincourse);
            filterTypes.Add(typeOfFood.dessert);
            filterTypes.Add(typeOfFood.appetizer);
            filterTypes.Add(typeOfFood.drink);

            leftList.Add(new Food() { Name = "Bécsi Szelet", Type = typeOfFood.maincourse, Cost = 2500 });
            leftList.Add(new Food() { Name = "Palacsinta", Type = typeOfFood.dessert, Cost = 1000 });
            leftList.Add(new Food() { Name = "Limonádé", Type = typeOfFood.drink, Cost = 1000 });
            ListCopy();

            check = false;
            Checked = new RelayCommand(() => Filter(selectedFilter));


            logic.SetupCollections(leftList, rightList, filteredList);
            AddToRight = new RelayCommand(
                () => logic.AddToRight(SelectedFromLeft),
                () => selectedFromLeft != null
                );

            RemoveFromRight = new RelayCommand(
                () => logic.RemoveFromRight(SelectedFromRight),
                () => selectedFromRight != null
                );
            Messenger.Register<MainWindowViewModel, string, string>(this, "MenuInfo", (recipient, msg) =>
            {
                OnPropertyChanged("AllCost");
                OnPropertyChanged("AddToRight");
                OnPropertyChanged("RemoveFromRight");


            });

        }
        public void Filter(typeOfFood type)
        {


            if (check)
            {
                check = false;
                ListCopy();
            }
            else
            {
                check = true;
                filteredList.Clear();
                foreach (Food food in leftList)
                {
                    if (food.Type == type)
                    {
                        filteredList.Add(food);
                    }
                }
            }



        }
        public void ListCopy()
        {


            filteredList.Clear();


            foreach (Food food in leftList)
            {
                filteredList.Add(food);
            }

        }


    }
}
