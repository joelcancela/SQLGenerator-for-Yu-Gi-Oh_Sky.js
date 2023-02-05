using SQLGenerator_for_Yu_Gi_Oh_Sky.js.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SQLGenerator_for_Yu_Gi_Oh_Sky.js.controller
{
    class Controller
    {
        private List<Card> cards = new List<Card>();
        private CardInfoRetriever cardInfoRetriever = new CardInfoRetriever();

        public Task<string> getRequests(string input, bool shouldUseStoredProc)
        {
            return Task.Run(() =>
            {
                try
                {
                    clearPreviousCardsInfo();
                    if (shouldUseStoredProc)
                    {
                        return createSQLRequestWithStoredProc(input);
                    }
                    else
                    {
                        return createSQLRequestWithoutStoredProc(input);
                    }
                }
                catch (Exception)
                {
                    return "Erreur lors de la récupération des détails des cartes, vérifiez votre saisie.";
                }
            });
        }

        private void clearPreviousCardsInfo()
        {
            cards.Clear();
            cardInfoRetriever = new CardInfoRetriever();
        }

        private string createSQLRequestWithStoredProc(string input)
        {
            createCardsFromInputs(input);
            string requestPrefix = "CALL InsertCard";
            string request = "";
            for (int i = 0; i < cards.Count; i++)
            {
                request += requestPrefix + cards[i].ToString() + ";\n";
            }
            return request;
        }

        private string createSQLRequestWithoutStoredProc(string input)
        {
            createCardsFromInputs(input);
            string request = "INSERT INTO `CARDS` (`name_fr`, `name`, `card_type`, `quantity`, `family`, `atk`, `def`, `level`, `text`, `property`, `type/0`, `type/1`, `type/2`, `type/3`, `deck/0`, `deck/1`, `deck/2`) VALUES ";
            request = createRequestSuffixForEveryCard(request);
            return request;
        }

        private void createCardsFromInputs(string input)
        {
            using (StringReader reader = new StringReader(input))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    createCard(line.Split(':'));
                }
            }
        }

        private string createRequestSuffixForEveryCard(string request)
        {
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

            return request;
        }

        private void createCard(string[] input)
        {
            Card card = new Card(input[0], int.Parse(input[1]));
            cardInfoRetriever.fillCardInfo(card);
            if(card.Name != null)
            {
                cards.Add(card);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Erreur pour "+input[0]);
            }
        }
    }
}
