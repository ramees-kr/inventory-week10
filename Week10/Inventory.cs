using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week10
{
    public partial class Inventory : Form
    {
        private InventoryDB inventoryDB;
        public Inventory()
        {
            InitializeComponent();
            inventoryDB = new InventoryDB(@"..\..\..\grocery_inventory_items.txt");
            LoadInventoryItems();
        }

        private void LoadInventoryItems()
        {
            List<InventoryItem> inventoryItems = inventoryDB.GetItems();
            foreach (var item in inventoryItems)
            {
                listBoxOfItems.Items.Add(item);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(inventoryDB.GetItems());
            addItemForm.ShowDialog();
            LoadInventoryItems();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxOfItems.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    InventoryItem selectedItem = (InventoryItem)listBoxOfItems.SelectedItem;
                    List<InventoryItem> items = inventoryDB.GetItems();
                    items.Remove(selectedItem);
                    inventoryDB.SaveItems(items);
                    listBoxOfItems.Items.Remove(selectedItem);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
