using System;
using System.Collections.Generic;
using System.IO;

namespace Skalitz
{
    // A class representing the shop 
    class Shop
    {
        string _shopName = "Generic Store";
        string _itemType1 = "type 1";
        string _itemType2 = "type 2";
        string _itemType3 = "type 3";
        

        bool _shopping = true;
        bool _buying = true;

        List<ShopItem> _shopItemList = new List<ShopItem>();
       List<ShopItem> _playerItemList = new List<ShopItem>();

        static string input;

        public Shop(string shopName="Grocer of Skalitz Store", string soldItem1="Food", string soldItem2="Drinks",
            string soldItem3="Raw Meat") 
        {
           InputShopItem();

            _shopName = shopName;
            _itemType1 = soldItem1;
            _itemType2 = soldItem2;
            _itemType3 = soldItem3;
        }

        public void OutputPlayerItem()
        {
            StreamWriter writer = new StreamWriter("../../PlayerInventory.txt");

            //Loop through the player inventory
            for (int i = 0; i < _playerItemList.Count; i++)
            {
                if (i != 0)
                {
                    writer.Write(",");
                }

                //Writes the shop item values out
                writer.Write($"{_playerItemList[i].GetName()}:{(int)_playerItemList[i].GetItemType()}:{_playerItemList[i].GetValue()}");
            }

            writer.Close();
        }

        private void InputShopItem()
        {
            StreamReader reader = new StreamReader("../../ShopInventory.txt");
            Random random = new Random();

            //Read the fist line
            string data = reader.ReadLine();

            while (data != null)
            {
                //Split the string into an array
                string[] shopItemSplitAr = data.Split(',');

                //For every string that we split, this will split it more 
                for (int i = 0; i < shopItemSplitAr.Length; i++)
                {
                    string[] itemAr = shopItemSplitAr[i].Split(":");
                    int type = int.Parse(itemAr[1]);
                    string name = itemAr[0];
                    

                    _shopItemList.Add(new ShopItem(name, random.Next(100, 1100), type));

                }

                data = reader.ReadLine();
            }

            reader.Close();
        }

       public void FillShop()
        {
            //Weapons
            _shopItemList.Add(new ShopItem("Herod's sword", 1100, (int)ShopItem.ItemType.Weapon));
            _shopItemList.Add(new ShopItem("Skalitz shield", 500, (int)ShopItem.ItemType.Weapon));
            _shopItemList.Add(new ShopItem("St. George's sword", 2000, (int)ShopItem.ItemType.Weapon));


            //Armor Items
            _shopItemList.Add(new ShopItem("Warhorse helmet", 100, (int)ShopItem.ItemType.Armor));
            _shopItemList.Add(new ShopItem("Noble cuirass", 500, (int)ShopItem.ItemType.Armor));
            _shopItemList.Add(new ShopItem("Zoul leg plate", 600, (int)ShopItem.ItemType.Armor));

            //Consumable Items
            _shopItemList.Add(new ShopItem("Spirits", 50, (int)ShopItem.ItemType.Consumable));
            _shopItemList.Add(new ShopItem("Drinking water", 10, (int)ShopItem.ItemType.Consumable));
            _shopItemList.Add(new ShopItem("Musk of Infinite Allure", 70, (int)ShopItem.ItemType.Consumable));
            _shopItemList.Add(new ShopItem("Padfoot potion", 70, (int)ShopItem.ItemType.Consumable));

        }

        public void ShopLoop()
        {
            PrintGreeting();

            while (_shopping)
            {

                input = Console.ReadLine();
                Console.Write("\n");

                if (input.Equals("Hi", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("Hello", StringComparison.OrdinalIgnoreCase))
                {
                    PrintGreeting();
                }
                else if (input.Equals("buy", StringComparison.OrdinalIgnoreCase))
                {
                    BuyLoop();
                }
                else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                         input.Equals("leave", StringComparison.OrdinalIgnoreCase))
                {
                    PrintFarewell();
                }
                else
                {
                    PrintError();
                }
            }
        }

        private void BuyLoop()
        {
            PrintItems();

            _buying = true;
            while (_buying)
            {
                input = Console.ReadLine();
                Console.Write("\n");

                int choice;
                if (int.TryParse(input, out choice))
                {
                    _playerItemList.Add(_shopItemList[choice - 1]);
                    _shopItemList.RemoveAt(choice - 1);

                    Console.WriteLine($"You have now purchased {_playerItemList[_playerItemList.Count - 1].GetName()}! Thank You!\n");

                    PrintItems();
                }
                else if (input.Equals("returns", StringComparison.OrdinalIgnoreCase) ||
                     input.Equals("back", StringComparison.OrdinalIgnoreCase))
                {
                    PrintGreeting();
                    _buying = false;
                }
            }
        }

    private void PrintItems()
        {
            Console.WriteLine("Please write the number next to the item you would like to buy.\n");

            for (int i = 0; i < _shopItemList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {_shopItemList[i].GetName()} - {_shopItemList[i].GetItemType().ToString()} - {_shopItemList[i].GetValue()} Groschen\n");
            }

            Console.WriteLine("What my lord would like to buy today?\n");
        }

        private void PrintGreeting()
        {
           
            Console.WriteLine($"{_shopName}, how can I serve you my lord ? ");
            Console.WriteLine($"We sell: {_itemType1}, {_itemType2}, {_itemType3} ");

        }

        private void PrintFarewell()
        {
            _shopping = false;

            Console.WriteLine("Hope you're satsified my lord !");
            Console.WriteLine("I wish you a safe journey");
        }

        private void PrintError()
        {
            Console.WriteLine("Please enter a valid command!");
        }
    }
}
