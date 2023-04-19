using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CSProject_API.Data
{
    public class customer
    {

        [BsonId]

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string FullName { get; set; }
        public double Phonenumber { get; set; }

     
       public string Eventlocation { get; set; }
      public string Typeofevent { get; set; }
      public int Numberofguest { get; set; }
        






    }
}
