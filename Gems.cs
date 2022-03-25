using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gems_N_Goblins
{
    public class Gems
    {
        private string _type;
        private string _rarity;
        private float _value;
        private int _weight;

        public string Type { get { return _type; } set { _type = value; } }
        public string Rarity { get { return _rarity; } set { _rarity = value; } }
        public float Value { get { return _value; } set { _value = value; } }
        public int Weight { get { return _weight; } set { _weight = value; } }
        public enum Quality
        {
            Chipped,
            Flawed,
            Normal,
            Flawless,
            Perfect
        }
        public enum Name
        {
            Emerald,
            Sapphire,
            Ruby,
            Topaz,
            Diamond,
            Amethyst
        }
        public Gems(string rarity, string type, int weight)
        {
            _type = type;
            _rarity = rarity;
            _weight = weight;
        }
        public static string[] GemRandomizer()
        {
            string[] gemVariable = new string[3] {"a","b","c"};
            Random rand = new Random();
            int randomNumber = rand.Next(0, 5); //Quality
            int randomNumber2 = rand.Next(0, 6);  //Name
            int randomNumber3 = rand.Next(1, 5);  //Weight
            var a = (Quality)randomNumber;
            var b = (Name)randomNumber2;
            gemVariable[0] = a.ToString();
            gemVariable[1] = b.ToString();
            gemVariable[2] = randomNumber3.ToString();
            return gemVariable;
        }
        public static float GemValue(string quality, string name)
        {
            float value = 0;
            float qualityRate = 0;
            int gemValue = 0;
            if (quality == "Chipped")
                qualityRate = 0.2f;
            if (quality == "Flawed")
                qualityRate = 0.5f;
            if (quality == "Normal")
                qualityRate = 1;
            if (quality == "Flawless")
                qualityRate = 1.3f;
            if (quality == "Perfect")
                qualityRate = 2;

            if (name == "Emerald")
                gemValue = 100;
            if (name == "Sapphire")
                gemValue = 250;
            if (name == "Ruby")
                gemValue = 400;
            if (name == "Topaz")
                gemValue = 600;
            if (name == "Amethyst")
                gemValue = 800;
            if (name == "Diamond")
                gemValue = 1000;

            value = gemValue * qualityRate;
            return value;
        }
    }
}
