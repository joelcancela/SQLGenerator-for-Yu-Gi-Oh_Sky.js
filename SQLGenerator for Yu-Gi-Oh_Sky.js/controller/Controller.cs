using SQLGenerator_for_Yu_Gi_Oh_Sky.js.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator_for_Yu_Gi_Oh_Sky.js.controller
{
    class Controller
    {
        private List<Card> cards = new List<Card>();
        private CardInfoRetriever cardInfoRetriever = new CardInfoRetriever();

        public Task<string> getRequests(string input)
        {
            return Task.Run(() =>
            {
                try
                {
                    string request = "INSERT INTO `CARDS` (`name_fr`, `name`, `card_type`, `quantity`, `family`, `atk`, `def`, `level`, `text`, `property`, `type/0`, `type/1`, `type/2`, `type/3`, `deck/0`, `deck/1`, `deck/2`) VALUES ";
                    cards.Clear();
                    cardInfoRetriever = new CardInfoRetriever();
                    using (StringReader reader = new StringReader(input))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            createCard(line.Split(':'));
                        }
                        for (int i = 0; i < cards.Count; i++)
                        {
                            request += cards[i].ToString();
                            if (i == cards.Count - 1)
                            {
                                request += ";";
                            }
                            else
                            {
                                request += ",";
                            }
                        }
                    }
                    return request;
                }
                catch(Exception)
                {
                    return "Erreur lors de la récupération des détails des cartes, vérifiez votre saisie.";
                }
            });
        }

        private void createCard(string[] input)
        {
            Card card = new Card(input[0], int.Parse(input[1]));
            cardInfoRetriever.fillCardInfo(card);
            cards.Add(card);
        }
    }
}
