using Advanced_Csharp_Lab2_Blazor.Models.mongo;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.ComponentModel;

namespace Advanced_Csharp_Lab2_Blazor.Data
{
    public class MongoDbService
    {
        private MongoClient Client { get; set; }

        private IMongoDatabase Database { get; set; }

        private IMongoCollection<Student> students { get; set; }
        public MongoDbService(IOptions<MongoDbOptions> options) {

            //get a new client using url
            Client = new MongoClient(options.Value.BaseUrl);
            //get the database
            Database = Client.GetDatabase(options.Value.Database);

            RefreshData();
        }

        public void RefreshData()
        {
            students = Database.GetCollection<Student>("Students");
        }

        public List<Student> GetStudents()
        {
            RefreshData();
            return students.AsQueryable().ToList();
        }

        public void AddStudent(Student student)
        {
            students.InsertOne(student);
        }

        public void RemoveStudent(Student student)
        {
            //declare a filter for finding the document to remove
            var filter = Builders<Student>.Filter.Eq(x => x._id, student._id);
            //use the filter with student collection
            var result = students.DeleteOne(filter);

        }


    }
}
