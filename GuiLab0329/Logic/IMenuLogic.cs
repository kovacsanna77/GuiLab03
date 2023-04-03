using GuiLab0329.Model;
using System.Collections.Generic;

namespace GuiLab0329.Logic
{
    public interface IMenuLogic
    {
        int AllCost { get; }

        void AddToRight(Food f);
        void RemoveFromRight(Food f);
        void SetupCollections(IList<Food> left, IList<Food> right, IList<Food> filtered);
    }
}