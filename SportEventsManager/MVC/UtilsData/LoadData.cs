using MVC.VIewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC.UtilsData
{
    public class LoadData
    { 
        private static readonly Uri urUser = new Uri("https://localhost:7215/api/user");
        private static readonly Uri urOrganisation = new Uri("https://localhost:7215/api/organisation");
        private static readonly Uri urEvent = new Uri("https://localhost:7215/api/event");
        public static SelectList LoadUserData()
        {
            var client = new WebClient();
            var body = "";

            body = client.DownloadString(urUser);
            var responseData = JsonConvert.DeserializeObject<List<UserVM>>(body);
            return new SelectList(responseData,"Id", "FirstName");
        }
        public static SelectList LoadOrganisationData()
        {
            var client = new WebClient();
            var body = "";

            body = client.DownloadString(urOrganisation);
            var responseData = JsonConvert.DeserializeObject<List<OrganisationVM>>(body);
            return new SelectList(responseData, "Id","Name");
        }
    }
}