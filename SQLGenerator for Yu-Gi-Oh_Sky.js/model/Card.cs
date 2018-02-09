using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator_for_Yu_Gi_Oh_Sky.js.model
{
    class Card
    {
        private string name;
        private string name_fr;
        private string card_type;
        private int quantity;
        private string family;
        private int atk;
        private int def;
        private int level;
        private string text;
        private string property;
        private string type0;
        private string type1;
        private string type2;
        private string type3;
        private string deck0;
        private string deck1;
        private string deck2;

        public Card(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get => name; set => name = value; }
        public string Name_fr { get => name_fr; set => name_fr = value; }
        public string Card_type { get => card_type; set => card_type = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Family { get => family; set => family = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Def { get => def; set => def = value; }
        public int Level { get => level; set => level = value; }
        public string Text { get => text; set => text = value; }
        public string Property { get => property; set => property = value; }
        public string Type0 { get => type0; set => type0 = value; }
        public string Type1 { get => type1; set => type1 = value; }
        public string Type2 { get => type2; set => type2 = value; }
        public string Type3 { get => type3; set => type3 = value; }
        public string Deck0 { get => deck0; set => deck0 = value; }
        public string Deck1 { get => deck1; set => deck1 = value; }
        public string Deck2 { get => deck2; set => deck2 = value; }

        public override string ToString()
        {
            return "(" + "'" + name_fr + "'," + "'" + name + "'," + "'" + card_type + "'," + "'" + quantity + "'," + "'" + family + "'," + "'" + atk + "'," + "'" + def + "'," + "'" + level + "'," + "'" + text + "'," + "'" + property + "'," + "'" + type0 + "'," + "'" + type1 + "'," + "'" + type2 + "'," + "'" + type3 + "'," + "'" + deck0 + "'," + "'" + deck1 + "'," + "'" + deck2 + "')";
        }
    }
}
