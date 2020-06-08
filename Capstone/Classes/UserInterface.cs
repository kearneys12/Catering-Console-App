using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere
        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.

        
        private CateringItem cateringItem = new CateringItem();
        public Catering catering = new Catering();
        int counter = 0;

        public void Initializing()
        {
            cateringItem.InitializedList();
            cateringItem.makeInventory();
            catering.StartupBalance();
            catering.SetDisplayList();
            catering.CateringList();
            catering.FixItemList();
        }

        public void RunInterface()
        {
            
          
            

            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine("Your current account balance is: $" + catering.AccountBalance());
            string userMainInput = Console.ReadLine();

            string answer = cateringItem.GetList();

            if (userMainInput == "1")
            {
                MainMenuInputOne();
            }

            else if(userMainInput == "2")
            {
                MainMenuInputTwo();
            }

            else if(userMainInput == "3")
            {
                MainMenuInputThree();
            }

            else
            {
                Console.WriteLine("That is not a valid option, please make a correct selection");
                Console.ReadLine();
                RunInterface();
            }

            void MainMenuInputOne() 
                
                {

                    answer = cateringItem.GetList().ToString();

                    Console.WriteLine(answer);
                    Console.WriteLine("Press enter to return to Main Menu");
                    Console.ReadLine();
                RunInterface();
                }

            
          void MainMenuInputTwo()
            {
                
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine("Your current account balance is: $" + catering.AccountBalance());
                string userOrderInput = Console.ReadLine();

                if( userOrderInput == "1")
                {
                    SecondMenuInputOne();
                }

                else if (userOrderInput == "2")
                {
                    SecondMenuInputTwo();
                }

                else if (userOrderInput == "3")
                {
                    SecondMenuInputThree();
                }

                else
                {
                    Console.WriteLine("That is not a valid option, please make a correct selection");
                    Console.ReadLine();
                    MainMenuInputTwo();
                }

                void SecondMenuInputOne()
                {
                    Console.WriteLine("Please enter dollar amount; total account withdrawal cannot exceed $5000");
                    string amountToAdd = Console.ReadLine();

                    try {
                       int addToAccount =  int.Parse(amountToAdd);

                        if( addToAccount >= 1 && addToAccount + catering.AccountBalance() <= 5000)
                        {
                            catering.AddFunds(addToAccount);
                            Console.WriteLine("Your new account balance is " + catering.AccountBalance());
                            Console.ReadLine();
                            MainMenuInputTwo();
                        }

                        else
                        {
                            throw new FormatException();
                        }
                    }

                    catch(FormatException)
                    {
                        Console.WriteLine("Your current balance is " + catering.AccountBalance() + ". Please enter a valid amount.");
                        Console.ReadLine();
                        MainMenuInputTwo();
                    }
                    


                }

                void SecondMenuInputTwo()
                {
                    catering.ResetPurchases();

                        if (counter == 0)
                        {
                            Console.WriteLine(cateringItem.GetList());
                            counter++;
                        }
                        else
                        {
                            Console.WriteLine(catering.ReturnList());
                        }

                        Console.WriteLine("Please enter the Item Number of the item you wish to purchase.");
                        string purchasingItem = Console.ReadLine().ToUpper();
                        Console.WriteLine("Please enter the amount you wish to purchase.");
                        string itemAmount = Console.ReadLine();
                        catering.PurchasingItem(purchasingItem, itemAmount);
                        bool result = catering.ItWasPurchased();
                   
                    try
                    {
                        if (result == true)
                        {
                            Console.WriteLine("Your purchase of " + purchasingItem + " was successful.");
                            Console.ReadLine();
                            catering.DeductInventory();
                            catering.DeductBalance();
                            MainMenuInputTwo();
                        }
                        else
                        {
                            Console.WriteLine("Your purchase was unsuccessful. Please try again.");
                            Console.ReadLine();
                            MainMenuInputTwo();
                        }

                    }

                    catch (FormatException)
                    {
                        Console.WriteLine("That item is currently sold out.");
                        Console.ReadLine();
                        MainMenuInputTwo();
                    }


                }

                void SecondMenuInputThree()
                {
                    Console.WriteLine("Your remaining balance is " + catering.AccountBalance());
                    Console.WriteLine(catering.GetChange());
                    Console.WriteLine("Your new balance is $0.");
                    catering.MakeLogList();
                    Console.WriteLine("Press any key to return to the main menu.");
                    Console.ReadLine();

                    RunInterface();
                }

                

            }

            void MainMenuInputThree()
            {


                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
                
            }

           
        }

       
    }
}
