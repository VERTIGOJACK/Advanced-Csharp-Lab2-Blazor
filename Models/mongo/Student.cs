using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Bson;
using System.Xml.Linq;

namespace Advanced_Csharp_Lab2_Blazor.Models.mongo
{
    public class Student
    {
        public ObjectId _id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set;}

        //convert to bson for database upload
        public BsonDocument ToBsonDocument()
        {
            return new BsonDocument
        {
            { "_id", _id },
            { "first_name", first_name },
            { "last_name", last_name }
        };
        }
    }
}
