using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using SQLGenerator_for_Yu_Gi_Oh_Sky.js.model;

namespace SQLGenerator_for_Yu_Gi_Oh_Sky.js.controller
{
    class CardInfoRetriever
    {
        private string card_name_fr_URL = "https://joelcancela.ddns.net/api/yugioh_sky.js/cardFrenchName?card_name=";
        private string card_details_URL = "http://yugiohprices.com/api/card_data/";
        internal void fillCardInfo(Card card)
        {
            string cardDetailsJSON = getAPIResponse(card_details_URL, card, false);
            if(cardDetailsJSON == null)
            {
                return;
            }
            JObject jsonDetails = JObject.Parse(cardDetailsJSON);
            JObject jsonDetailsData = (JObject)jsonDetails.GetValue("data");
            card.Name = ((string)jsonDetailsData.GetValue("name")).Replace(@"'", @"\'");
            card.Text = ((string)jsonDetailsData.GetValue("text")).Replace(@"'", @"\'");
            card.Card_type = (string)jsonDetailsData.GetValue("card_type");
            card.Family = (string)jsonDetailsData.GetValue("family");
            JToken atk = jsonDetailsData.GetValue("atk");
            if(atk.Type != JTokenType.Null)
            {
                card.Atk = (int)atk;
            }
            JToken def = jsonDetailsData.GetValue("def");
            if (def.Type != JTokenType.Null)
            {
                card.Def = (int)def;
            }
            JToken level = jsonDetailsData.GetValue("level");
            if (level.Type != JTokenType.Null)
            {
                card.Level = (int)level;
            }
            card.Property = (string)jsonDetailsData.GetValue("property");
            JToken type = jsonDetailsData.GetValue("type");
            if (type.Type != JTokenType.Null)
            {
                string typesString = (string)type;
                string[] types = typesString.Split(new string[] { " / " }, StringSplitOptions.None);
                for (int i = 0; i < types.Length; i++)
                {
                    card.Types[i] = types[i];
                }
            }
            string cardNameFrResponse = getAPIResponse(card_name_fr_URL, card, true);
            if (cardNameFrResponse != null)
            {
                card.Name_fr = cardNameFrResponse.Replace(@"'", @"\'");
            }
        }

        private string getAPIResponse(string URL, Card card, bool isTranslationCall)
        {
            WebRequest request = WebRequest.Create(URL + card.Name);
            string responseFromServer = null;
            try
            {
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
            }
            catch (Exception)
            {
                if (isTranslationCall)
                {
                    responseFromServer = card.Name;
                }
            }
            return responseFromServer;
        }
    }
}
