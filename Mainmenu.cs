using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Gems_N_Goblins
{
    public class Mainmenu
    {
        public static void ShowChestContent()
        {
            int[] gemTotal = new int[2];
            gemTotal = Contenant.GemTotal();
            string menu = "╔════════════════════════════════════════════╗\n" +
                          "║                Chest Content               ║\n";
            int index = 1;
            foreach (Gems gem in Contenant.gemList)
            {
                menu += String.Format("║ {0,-1} - {1,-8} {2,-10}|{3,5} $ |{4,4} lbs. ║\n", index, gem.Rarity,gem.Type, gem.Value, gem.Weight);
                index++;
            }
            menu += $"║ ------------------------------------------ ║\n";
            menu += String.Format("║    Total               |{0,5} $ |{1,4} lbs. ║\n", gemTotal[0],gemTotal[1]);
            menu +=  "╚════════════════════════════════════════════╝\n";
            Console.Clear();
            Console.WriteLine(menu);
        }
        public static void SellGems()
        {
            
        }
        public static void GemUserInput(Gems gemme)
        {
            string input;
            Console.WriteLine("Do you want to keep this gem?");
            do input = Console.ReadLine();
            while (input != "Y" && input != "y" && input != "N" && input != "n");
            switch (input)
            {
                case "Y":
                case "y":
                    Program.chest.AddGemToChest(gemme);
                    Console.ReadKey();
                    break;
                case "N":
                case "n":
                    Console.WriteLine($"The {gemme.Type} wasn't added to the chest.");
                    Console.ReadKey();
                    break;
            }
        }
        public static void ChestUserInput()
        {
            string input;
            Contenant.DrawChest();
            Console.WriteLine("1: Open new chest. 2: See current inventory.");
            do input = Console.ReadLine();
            while (input != "1" && input != "2");
            switch (input)
            {
                case "1":
                    Contenant.DrawCloseChest();
                    break;
                case "2":
                    ShowChestContent();
                    InventoryUserInput();
                    break;
            }
        }
        public static void InventoryUserInput()
        {
            string input;
            int gemme;
            Console.WriteLine("1: Remove gem from inventory. 2: Back to chest opening.");
            do input = Console.ReadLine();
            while (input != "1" && input != "2");
            switch (input)
            {
                case "1":
                    gemme = RemoveUserInput();
                    Console.WriteLine($"A {Contenant.gemList[gemme - 1].Rarity} {Contenant.gemList[gemme-1].Type} has been removed from the inventory.");
                    Program.chest.RemoveGemFromChest(Contenant.gemList[gemme-1]);
                    Console.ReadKey();
                    ChestUserInput();
                    break;
                case "2":
                    ChestUserInput();
                    break;
            }
        }
        public static int RemoveUserInput()
        {
            int input = 0;
            
            Console.WriteLine("Select item to remove.");
            do
            {
                try
                {
                        input = 0;
                        input = int.Parse(Console.ReadLine());
                    }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect Entry.");
                }
            }
            while (input <= 0 || input > Contenant.gemList.Count);

            return input;
        } 
    }
}
