using WebAPIShipManagement.Models;
using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
namespace WebAPIShipManagement.Data
{
    public class PortSeedData
    {
        public static void Initialize(ShipContext context)
        {
            context.Database.EnsureCreated();
            if (context.Ports.Any())
            {
                return;   // DB has been seeded
            }

            using (StreamReader r = new StreamReader(@"App_Data\portDetails.json"))
            {
                var json = r.ReadToEnd();
                var portDetails = JsonConvert.DeserializeObject<List<PortModel>>(json);
                foreach (var details in portDetails)
                {
                    context.Ports.Add(details);
                    context.SaveChanges();
                }
            }           
            //context.SaveChanges();
        }
    }
}
