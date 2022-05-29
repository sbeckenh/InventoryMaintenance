using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // Add a statement here that declares the list of items.
        private List<InvItem> invItem = null;
        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // Add a statement here that gets the list of items.
            invItem = InvItemDB.GetItems();
            FillItemListBox();
        }

        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // Add code here that loads the list box with the items in the list.
            foreach (InvItem item in invItem)
            {
                lstItems.Items.Add(item.GetDisplayText());
            }
        }
            public string GetDisplayText() => invItem.Count.ToString();

        private List<InvItem> GetInvItem()
        {
            return invItem;
        }

        private ListBox GetLstItems()
        {
            return lstItems;
        }

        private void btnAdd_Click(object sender, EventArgs e, List<InvItem> invItem, ListBox lstItems)
        {
            // Add code here that creates an instance of the New Item form
            frmNewItem newItem = new frmNewItem();
            // and then gets a new item from that form.
            newItem.GetNewItem();
            if (invItem != null)
            {
                invItem.Add();
                InvItemDB.SaveItems(invItem);
                FillItemListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e, InvItem invItem, InvItem newInvItem)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                string message = "Are you sure you want to delete "
                    + newInvItem + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    newInvItem.Remove(newInvItem);
                    InvItem newInvItem1 = newInvItem;
                    InvItemDB.SaveItems(newInvItem1);
                    FillItemListBox();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
