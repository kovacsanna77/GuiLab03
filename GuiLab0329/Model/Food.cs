using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiLab0329.Model
{
    public class Food: ObservableObject
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		private typeOfFood type;

		public typeOfFood Type
		{
			get { return type; }
			set { SetProperty(ref type , value); }
		}

		private int cost;

		public int Cost
		{
			get { return cost; }
			set { SetProperty(ref cost, value); }
		}

		public Food GetCopy()
		{
			return new Food()
			{
				Name = this.name,
				Type = this.type,
				Cost = this.cost,

			};
		}


	}

	public enum typeOfFood
	{
		dessert, maincourse, drink, appetizer
	}
}
