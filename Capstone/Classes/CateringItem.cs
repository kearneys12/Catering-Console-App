using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item

        FileAccess fileAccess = new FileAccess();


        List<string> calledList = new List<string>();
        
        
        public List<int> inventoryList = new List<int>();


        public void InitializedList()
        {

            calledList = fileAccess.AccessCateringItem();

        }


        public void makeInventory()
        {
            for (int i = 0; i < calledList.Count; i = i + 4)
            {
                inventoryList.Add(50);
                inventoryList.Add(0);
                inventoryList.Add(0);
                inventoryList.Add(0);
                
            }

        }

        public string GetList()
        {

            string menu = "";
            for(int i = 0; i < calledList.Count; i = i + 4)
            {
                menu = menu +  (calledList[i] + " | " + calledList[i+1] + " | " + calledList[i+2] + " | " + calledList[i+3] + " | " + inventoryList[i] + Environment.NewLine);
            }
            return menu;
        }

        

        

        



    }
}
