namespace Gems_N_Goblins
{ 
    public class Program
    {
        public static bool inProgress = true;
        public static Contenant chest = new Contenant(25);
        //public static Gems gemme;
        static void Main(string[] args)
        {
            while (inProgress)
            {
                Mainmenu.ChestUserInput();
                string[] gemAttribute = Gems.GemRandomizer();
                Gems gemme = new(gemAttribute[0], gemAttribute[1],int.Parse(gemAttribute[2]));
                gemme.Value = Gems.GemValue(gemAttribute[0], gemAttribute[1]);
                Console.WriteLine($"You found a {gemme.Type} of {gemme.Rarity} quality weighting {gemme.Weight} lbs");
                Console.WriteLine($"The value of the gem is {gemme.Value}$");
                Console.WriteLine($"Do you want to add it to your bag? Y/N");
                Mainmenu.GemUserInput(gemme);
                Console.Clear();
                Contenant.DrawOpenChest();
                
                Console.Clear();
            }
        }
    }
}
