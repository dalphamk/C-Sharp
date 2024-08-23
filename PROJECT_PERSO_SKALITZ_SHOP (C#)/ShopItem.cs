using System;
using System.Collections.Generic;
using System.Text;

namespace Skalitz
{
    // A class representing the items that the shop will contain
    class ShopItem
    {
        private string _itemName;
        private int _itemValue;
        private ItemType _type;

        public enum ItemType
        {
            Weapon,  //0
            Armor,  //1
            Consumable  //2
        }

        public ShopItem(string name, int value, int typeInt)
        {
            _itemName = name;
            _itemValue = value;
            _type = (ItemType)typeInt;
        }

        public string GetName()
        {
            return _itemName;
        }

        public int GetValue()
        {
            return _itemValue;
        }

        public ItemType GetItemType()
        {
            return _type;
        }
    }
}
