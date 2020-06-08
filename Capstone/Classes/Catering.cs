using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        FileAccess fileAccess = new FileAccess();
        CateringItem cateringItem = new CateringItem();
        public List<string> displayList = new List<string>();
        
        private List<string> items = new List<string>();
        
        List<int> newInventoryList = new List<int>();

        List<string> logList = new List<string>();

        bool ableToPurchase = false;
        string itemName = "";
        int newItemAmount = 0;
        decimal totalCost = 0;
       // private string filePath = @"C:\Catering\cateringsystem.csv";


        string newMenu = "";
        decimal balance = 0;
        public void SetList()
        {
            
        }
        public void StartupBalance()
        {
            balance = 0;
        }

        public void AddFunds(decimal addToAccount)
        {
            balance += addToAccount;

            logList.Add(DateTime.Now.ToString("g") + " ADD MONEY $" + addToAccount + Environment.NewLine + "$" + balance + Environment.NewLine);

            //call method to write log to log.txt
        }



        public decimal AccountBalance()
        {
            return balance;
        }
        public void SetDisplayList()
        {
            displayList = fileAccess.AccessCateringItem();
        }

        public void FixItemList()
        {
            for (int i = 4; i < items.Count; i = i + 5)
            {
                items.Insert(i, "50");
            }
            items.Add("50");
        }

        public void CateringList()
        {

            items = fileAccess.AccessCateringItem();


            for (int i = 0; i < items.Count; i = i + 5)
            {
                newInventoryList.Add(50);
                newInventoryList.Add(0);
                newInventoryList.Add(0);
                newInventoryList.Add(0);
                newInventoryList.Add(0);
            }


            for (int i = 0; i < items.Count; i = i + 4)
            {
                
                newMenu = newMenu + (items[i] + " | " + items[i + 1] + " | " + items[i + 2] + " | " + items[i + 3] + " | " + newInventoryList[i] + Environment.NewLine);

            }
            
        }

        public void PurchasingItem(string purchasingItem, string itemAmount)
        {
            

            for (int i = 0; i < items.Count; i++)
            {
               

               if (purchasingItem == items[i])
                {
                    

                    itemName = items[i + 1];

                    string itemCost = items[i + 2];

                    newItemAmount = int.Parse(items[i + 4]) - int.Parse(itemAmount);

                    totalCost = decimal.Parse(itemCost) * decimal.Parse(itemAmount);


                    if (newItemAmount >= 0 && totalCost <= balance && totalCost > 0)
                    {

                        ableToPurchase = true;

                        logList.Add(DateTime.Now.ToString("g") + " " + itemAmount + " " + itemName + " " + items[i] + Environment.NewLine);


                        //call method to write log to log.txt
                    }

                }





            }
        }

   
        public void ResetPurchases()
        {
            ableToPurchase = false;
            totalCost = 0;
            newItemAmount = 0;
            
        }

        public bool ItWasPurchased()
        {
            return ableToPurchase;
        }

        public void DeductInventory()
        {
            for (int i = 0; i < items.Count; i += 5)
            {
                if (items[i + 1] == itemName)
                {
                    items[i + 4] = newItemAmount.ToString();

                if(newItemAmount == 0)
                    {
                        items[i + 4] = "SOLD OUT";
                    }
                }
            }
        }


        public void DeductBalance()
        {
            balance -= totalCost;
        }


        public string ReturnList()
        {
            string menu = "";
            for (int i = 0; i < items.Count; i = i + 5)
            {
                menu = menu + (items[i] + " | " + items[i + 1] + " | " + items[i + 2] + " | " + items[i + 3] + " | " + items[i + 4] + Environment.NewLine);
            }
            return menu;
        }


        public string GetChange()
        {
            logList.Add("GIVE CHANGE: $" + balance + " $0.00");

            int twenty = 0;
            int tens = 0;
            int fives = 0;
            int ones = 0;
            decimal quarters = 0;
            decimal dimes = 0;
            decimal nickels = 0;

            while(balance >= 20)
            {
                twenty += 1;
                balance -= 20;
            }

            while (balance >= 10)
            {
                tens += 1;
                balance -= 10;
            }

            while (balance >= 5)
            {
                fives += 1;
                balance -= 5;
            }

            while (balance >= 1)
            {
                ones += 1;
                balance -= 1;
            }

            while (balance >= (decimal).25)
            {
                quarters += 1;
                balance = balance - (decimal).25;
            }

            while (balance >= (decimal).1)
            {
                dimes += 1;
                balance -= (decimal).1;
            }

            while (balance >= (decimal).05)
            {
                nickels += 1;
                balance -= (decimal).05;
            }

            string totalRefund = "Twenties - " + twenty + " Tens - " + tens + " Fives - " + fives + " Ones - " + ones + " Quarters - " + quarters + " Dimes - " + dimes + " Nickles - " + nickels;

            
            return totalRefund;

        }


        public void MakeLogList()
        {
            fileAccess.CreateLogList(logList);
        }

    }
}
