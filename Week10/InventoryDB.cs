using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;

namespace Week10
{
    public class InventoryDB
    {
        private readonly string filePath;
        private const char Delimiter = '|';

        public InventoryDB(string filePath)
        {
            this.filePath = filePath;
        }

        public List<InventoryItem> GetAllItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(Delimiter);
                    InventoryItem item = new InventoryItem
                    {
                        ItemNo = int.Parse(parts[0]),
                        Description = parts[1],
                        Price = decimal.Parse(parts[2])
                    };
                    items.Add(item);
                }
            }

            return items;
        }

        public void AddItem(InventoryItem newItem)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(newItem);
            }
        }

        public void DeleteItem(int itemNo)
        {
            List<InventoryItem> items = GetAllItems();
            InventoryItem itemToRemove = items.FirstOrDefault(item => item.ItemNo == itemNo);

            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (InventoryItem item in items)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }
    }
}
