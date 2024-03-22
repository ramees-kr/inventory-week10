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
    public partial class AddItemForm : Form
    {
        private List<InventoryItem> inventoryItems;

        public AddItemForm(List<InventoryItem> items)
        {
            InitializeComponent();
            inventoryItems = items;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int itemNo;
            if (!int.TryParse(txtBoxItemNumber.Text, out itemNo))
            {
                MessageBox.Show("Invalid item number. Please enter a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal price;
            if (!decimal.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Invalid price. Please enter a valid decimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            InventoryItem newItem = new InventoryItem
            {
                ItemNo = itemNo,
                Description = txtBoxDescription.Text,
                Price = price
            };

            inventoryItems.Add(newItem);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
