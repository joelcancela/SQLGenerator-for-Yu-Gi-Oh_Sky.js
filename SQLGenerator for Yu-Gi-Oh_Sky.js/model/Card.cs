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
        private string[] types = { null, null, null, null };
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
        public string[] Types { get => types; set => types = value; }
        public string Property { get => property; set => property = value; }
        public string Deck0 { get => deck0; set => deck0 = value; }
        public string Deck1 { get => deck1; set => deck1 = value; }
        public string Deck2 { get => deck2; set => deck2 = value; }

        public override string ToString()
        {
            return "(" + "'" + name_fr + "'," + "'" + name + "'," + "'" + card_type + "'," + "'" + quantity + "'," + "'" + family + "'," + "'" + atk + "'," + "'" + def + "'," + "'" + level + "'," + "'" + text + "'," + "'" + property + "'," + "'" + types[0] + "'," + "'" + types[1] + "'," + "'" + types[2] + "'," + "'" + types[3] + "'," + "'" + deck0 + "'," + "'" + deck1 + "'," + "'" + deck2 + "')";
        }
    }
}
