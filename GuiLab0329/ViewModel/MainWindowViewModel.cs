using GuiLab0329.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace GuiLab0329.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {

       public  ObservableCollection<Food> leftList { get; set; }
        public ObservableCollection<Food> rightList { get; set; }

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
                selectedFromRight = value; 
            }
        }


        public ICommand AddToRight { get; set; }
        public  ICommand RemoveFromRight { get; set; }
        public ICommand Doubleclick { get; set; }
        
        public int AllCost
        {
            get
            {
                return rightList.Count == 0 ? 0 : rightList.Sum(t => t.Cost);

            }
        }

        public MainWindowViewModel()
        {

            leftList = new ObservableCollection<Food>();
            rightList = new ObservableCollection<Food>();

            leftList.Add(new Food() { Name = "Bécsi Szelet", Type = typeOfFood.maincourse, Cost = 2500 });
            leftList.Add(new Food() { Name = "Palacsinta", Type = typeOfFood.dessert, Cost = 1000 });
            leftList.Add(new Food() { Name = "Limonádé", Type = typeOfFood.drink, Cost = 1000 });

            rightList.Add(leftList[0]);

            AddToRight = new RelayCommand(
                () => rightList.Add(SelectedFromLeft),
                ()=> SelectedFromLeft != null
                );

            RemoveFromRight = new RelayCommand(
                () => rightList.Remove(SelectedFromRight)
                
                );

            Doubleclick = new RelayCommand(() => Edit(SelectedFromLeft));

        }

        public void Edit(Food f)
        {
            new EditWindow(f).ShowDialog();
        }
    }
}
