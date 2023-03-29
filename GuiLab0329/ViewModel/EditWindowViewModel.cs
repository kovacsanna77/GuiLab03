using GuiLab0329.Model;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiLab0329.ViewModel
{
    public class EditWindowViewModel
    {
        public Food Current { get; set;}

        public void Setup(Food f){ this.Current = f; }

        public EditWindowViewModel()
        {

        }
    }
}
