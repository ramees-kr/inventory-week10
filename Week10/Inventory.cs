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
        private readonly string filePath = @"..\..\..\InventoryItems.txt";

        public Inventory()
        {
            InitializeComponent();
            inventoryDB = new InventoryDB(filePath);
            LoadItemsToListBox();
        }

        private void LoadItemsToListBox()
        {
            listBoxOfItems.Items.Clear();
            foreach (InventoryItem item in inventoryDB.GetAllItems())
            {
                listBoxOfItems.Items.Add(item.ToString());
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddItemForm addItemForm = new AddItemForm(inventoryDB);
            addItemForm.ShowDialog();
            LoadItemsToListBox();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxOfItems.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string selectedItem = listBoxOfItems.SelectedItem.ToString();
                    string[] parts = selectedItem.Split('|');
                    int itemNo = int.Parse(parts[0]);
                    inventoryDB.DeleteItem(itemNo);
                    LoadItemsToListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBoxOfItems_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
