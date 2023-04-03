using GuiLab0329.Model;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GuiLab0329.Logic
{
    public class MenuLogic : IMenuLogic
    {
        IList<Food> left;
        IList<Food> right;
        IList<Food> filtered;
        IMessenger messenger;

        public MenuLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void SetupCollections(IList<Food> left, IList<Food> right, IList<Food> filtered)
        {
            this.left = left;
            this.right = right;
            this.filtered = filtered;
        }
        public int AllCost
        {
            get
            {

                return right.Count == 0 ? 0 : right.Sum(r => r.Cost);

            }
        }

        public void AddToRight(Food f)
        {
            right.Add(f);
            messenger.Send("Food Added", "MenuInfo");


        }

        public void RemoveFromRight(Food f)
        {
            right.Remove(f);
            messenger.Send("Food removed", "MenuInfo");
        }

    }
}
