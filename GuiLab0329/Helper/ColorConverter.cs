using GuiLab0329.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GuiLab0329.Helper
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            typeOfFood v = (typeOfFood)value;

            if(v == typeOfFood.appetizer)
            {
               return Brushes.LightCoral;
            }else if(v == typeOfFood.dessert)
            {
                return Brushes.LightBlue;
            }else if(v == typeOfFood.maincourse)
            {
                return Brushes.LightGreen;
            }else if( v == typeOfFood.drink)
            {
                return Brushes.LightGoldenrodYellow;
            }

            return Brushes.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
