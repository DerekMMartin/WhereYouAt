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
            Locations location = new Locations();
            EmbeddedLocationData locationData = new EmbeddedLocationData();

            locationData.ID = new ObjectId("5b0d9ef5c1b8aa49b8f64fc9");
            locationData.Latitude = 34.3443d;
            locationData.Longitude = 3.34d;
            locationData.Restrictions = new List<ObjectId> { new ObjectId("5b0f3f7ec1b8aa1b68e1fa17") };
            locationData.LocationImage = null;
            locationData.ExpiresAt = DateTime.Now;

            location.ID = new ObjectId("5b060d22c1b8aa0a843fabb7");
            location.UserId = ObjectId.GenerateNewId();
            location.LocationData = new List<EmbeddedLocationData> { locationData };

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
                Console.WriteLine($"image: {data.LocationImage}");
                foreach (var restrict in data.Restrictions)
                {
                    Console.WriteLine($"restrict: {restrict}");
                }
            }

            //locationData.ID = new ObjectId("5b0d9ef5c1b8aa49b8f64ff9");
            //locationData.ExpiresAt = DateTime.Now;
            //test.Update(location);
            //test.UpdateOneEmbeddedData(location, locationData);
            //test.AppendNewDataItem(location, locationData);

            //Console.WriteLine();
            //tempLocation = test.RetrieveOneDocument<Locations>(location.ID);
            //Console.WriteLine($"id: {tempLocation.ID}");
            //Console.WriteLine($"user Id: {tempLocation.UserId}");
            //foreach (var data in tempLocation.LocationData)
            //{
            //    Console.WriteLine();
            //    Console.WriteLine($"ID: {data.ID}");
            //    Console.WriteLine($"expires: {data.ExpiresAt}");
            //    Console.WriteLine($"latitude: {data.Latitude}");
            //    Console.WriteLine($"longitude: {data.Longitude}");
            //    Console.WriteLine($"image: {data.LocationImage}");
            //    foreach (var restrict in data.Restrictions)
            //    {
            //        Console.WriteLine($"restrict: {restrict}");
            //    }
            //}
        }
    }
}
