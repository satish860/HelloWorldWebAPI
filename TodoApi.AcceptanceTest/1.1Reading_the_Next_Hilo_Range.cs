using Newtonsoft.Json.Linq;
using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;



namespace TodoApi.AcceptanceTest
{
    public class Hilo_Range_for_Entities_Spec : nspec
    {
        public void When_the_Client_ask_for_the_next_Range()
        {
            it["Should be possible to get the next low and high range"] = () =>
            {
                var client = HttpClientFactory.CreateClient();
                HttpResponseMessage responseMessage = client.GetAsync("api/Hilo/Todo").Result;
                responseMessage.StatusCode.should_be(HttpStatusCode.OK);
                JObject HiloObject = JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);
                JValue HighValue = (JValue)HiloObject["High"];
                JValue Capacity=  HiloObject["Capacity"] as JValue;
                HighValue.Value.should_be(1);
                Capacity.Value.should_be(10);
            };
        }
    }
}
