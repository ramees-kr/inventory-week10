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

        private InventoryDB inventoryDB;

        public AddItemForm(InventoryDB inventoryDB)
        {
            InitializeComponent();
            this.inventoryDB = inventoryDB;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBoxItemNumber.Text) &&
                !string.IsNullOrWhiteSpace(txtBoxDescription.Text) &&
                !string.IsNullOrWhiteSpace(textBoxPrice.Text))
            {
                int itemNo = int.Parse(txtBoxItemNumber.Text);
                string description = txtBoxDescription.Text;
                decimal price = decimal.Parse(textBoxPrice.Text);

                InventoryItem newItem = new InventoryItem { ItemNo = itemNo, Description = description, Price = price };
                inventoryDB.AddItem(newItem);

                MessageBox.Show("Item added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                Close();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearFields()
        {
            txtBoxItemNumber.Clear();
            txtBoxDescription.Clear();
            textBoxPrice.Clear();
        }
    }
}
