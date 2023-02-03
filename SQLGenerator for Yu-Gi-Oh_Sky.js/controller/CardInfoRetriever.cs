﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            string cardDetailsJSON = getAPIResponse(card_details_URL, card);
            JObject jsonDetails = JObject.Parse(cardDetailsJSON);
            JObject jsonDetailsData = (JObject)jsonDetails.GetValue("data");
            card.Name = ((string)jsonDetailsData.GetValue("name")).Replace(@"'", @"\'");
            card.Text = ((string)jsonDetailsData.GetValue("text")).Replace(@"'", @"\'");
            card.Card_type = (string)jsonDetailsData.GetValue("card_type");
            card.Family = (string)jsonDetailsData.GetValue("family");
            card.Atk = (int)jsonDetailsData.GetValue("atk");
            card.Def = (int)jsonDetailsData.GetValue("def");
            card.Level = (int)jsonDetailsData.GetValue("level");
            card.Property = (string)jsonDetailsData.GetValue("property");
            string typesString = (string)jsonDetailsData.GetValue("type");
            string[] types = typesString.Split(new string[] { " / " }, StringSplitOptions.None);
            for(int i=0; i<types.Length; i++)
            {
                card.Types[i] = types[i];
            }
            card.Name_fr = getAPIResponse(card_name_fr_URL, card).Replace(@"'", @"\'");
        }

        private string getAPIResponse(string URL, Card card)
        {
            WebRequest request = WebRequest.Create(URL + card.Name);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return responseFromServer;
        }
    }
}
