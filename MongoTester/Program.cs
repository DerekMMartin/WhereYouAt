using MongoConnectionLib.Modules;
using MongoConnectionLib.Services;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTester
{
    class Program
    {
        static void Main(string[] args)
        {
            MobileService test = new MobileService();
            EmbeddedLocationData locationData = new EmbeddedLocationData
            {
                ID = new ObjectId("5b0d9ef5c1b8aa49b8f64fc9"),
                Latitude = 34.3443d,
                Longitude = 34.34d,
                ViewRestrictions = new List<ObjectId> { new ObjectId("5b0f3f7ec1b8aa1b68e1fa17") },
                ImageLocation = null,
                ExpiresAt = DateTime.Now
            };

            Locations location = new Locations
            {
                ID = new ObjectId("5b060d22c1b8aa0a843fabb7"),
                UserId = ObjectId.GenerateNewId(),
                LocationData = new List<EmbeddedLocationData> { locationData }
            };

            //test.Insert(location);

            //foreach (ObjectId temp in test.RetrieveAllDocumentIds<Locations>())
            //{
            //    Console.WriteLine(temp);
            //}

            var tempLocation = test.RetrieveOneDocument<Locations>(location.ID);
            Console.WriteLine($"id: {tempLocation.ID}");
            Console.WriteLine($"user Id: {tempLocation.UserId}");
            foreach (var data in tempLocation.LocationData)
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {data.ID}");
                Console.WriteLine($"expires: {data.ExpiresAt}");
                Console.WriteLine($"latitude: {data.Latitude}");
                Console.WriteLine($"longitude: {data.Longitude}");
                Console.WriteLine($"image: {data.ImageLocation}");
                foreach (var restrict in data.ViewRestrictions)
                {
                    Console.WriteLine($"restrict: {restrict}");
                }
            }

            //locationData.ID = new ObjectId("5b0d9ef5c1b8aa49b8f64ff9");
            test.DeleteEmbeddedDocument(location, locationData);
            //locationData.ExpiresAt = DateTime.Now;
            //test.Update(location);
            ////test.AppendNewDataItem(location, locationData);
            //test.UpdateOneEmbeddedData(location, locationData);

            Console.WriteLine();
            tempLocation = test.RetrieveOneDocument<Locations>(location.ID);
            Console.WriteLine($"id: {tempLocation.ID}");
            Console.WriteLine($"user Id: {tempLocation.UserId}");
            foreach (var data in tempLocation.LocationData)
            {
                Console.WriteLine();
                Console.WriteLine($"ID: {data.ID}");
                Console.WriteLine($"expires: {data.ExpiresAt}");
                Console.WriteLine($"latitude: {data.Latitude}");
                Console.WriteLine($"longitude: {data.Longitude}");
                Console.WriteLine($"image: {data.ImageLocation}");
                foreach (var restrict in data.ViewRestrictions)
                {
                    Console.WriteLine($"restrict: {restrict}");
                }
            }
        }
    }
}
