using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using Model;
using ViewModel;
using System.Runtime.CompilerServices;

namespace MetallicaService
{
    public class APIcommscs
    {
        String apiPath = "https://app.ticketmaster.com/discovery/v2/events?apikey=vMfT2Kz36az5xeLMIoyc12xZOXT7iSID&attractionId=K8vZ9171G9V&locale=*&size=100";


        public ShowList getAllShows()
        {

            ShowList list = MakeApiCall();
            Console.WriteLine("reached here");
            return list;
        }

        public ShowList MakeApiCall()
        {
            ShowList list = new ShowList();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send GET request synchronously
                    HttpResponseMessage response = client.GetAsync(apiPath).Result;

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        JObject json = JObject.Parse(content);

                        JArray events = (JArray)json["_embedded"]["events"];
                        foreach (JToken eventToken in events)
                        {
                            string name = eventToken["name"].ToString();
                            string url = eventToken["url"].ToString();
                            string localDateStr = eventToken["dates"]["start"]["localDate"].ToString();

                            DateTime localDate = DateTime.ParseExact(localDateStr, "yyyy-MM-dd", null);

                            string formattedDate = localDate.ToString("dd-MM-yyyy");
                            string stadiumName = eventToken["_embedded"]["venues"][0]["name"].ToString();
                            string stadiumCity = eventToken["_embedded"]["venues"][0]["city"]["name"].ToString();
                            string stadiumCountry = eventToken["_embedded"]["venues"][0]["country"]["name"].ToString();

                            Show show = new Show();
                            show.City = stadiumCity;
                            show.StadiumName = stadiumName;
                            show.Country = stadiumCountry;
                            show.ShowDate = localDate;
                            show.ShowName = name;
                            show.Url = url;
                            list.Add(show);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return null;
                }
                return list;
            }
        }

    }
}
