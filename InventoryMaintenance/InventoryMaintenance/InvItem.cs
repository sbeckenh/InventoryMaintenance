using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    // InvItem Class
    public class InvItem
    {
        private string text1;
        private string text2;
        private decimal v;

        public InvItem()
        {
        }
        public InvItem(int ItemNo, string Description, decimal Price) =>
            (this.ItemNo, this.Description, this.Price) =(ItemNo, Description, Price);

        public InvItem(string text1, string text2, decimal v)
        {
            this.text1 = text1;
            this.text2 = text2;
            this.v = v;
        }

        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string GetDisplayText() => ItemNo + " " + Description + " " + "(" + Price + ")";

        internal void Remove(InvItem invItem)
        {
            throw new NotImplementedException();
        }
    }
     
    
}
