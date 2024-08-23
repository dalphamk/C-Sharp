using System;
using System.Collections.Generic;
/**
 * Author: Alpha Mamadou Diallo
 * 
 * Version: 1.0
 * 
 * Date: August 2022
 * 
 * Desctiption: This class emulates an item shop inspired from the one
 * in the Skalitz a town in the video-game hit "Kingdom Come Deliverance" 
 * 
 * */
namespace Skalitz
{
    class Program
    {
        static Shop skalitzBlacksmithStore = new Shop("Skalitz Armory Shop", "Weapons", "Armor Kit", "Shield");

        static void Main(string[] args)
        {
            skalitzBlacksmithStore.ShopLoop();

            skalitzBlacksmithStore.OutputPlayerItem();
        }

    }
}
