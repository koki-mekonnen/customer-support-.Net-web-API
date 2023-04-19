using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CSProject_API.Data
{
    public class customerservice
    {
        private readonly IMongoCollection<customer> _customer;

        public customerservice(IOptions<DBsettings> options)
        {
          var mongoClient= new MongoClient(options.Value.ConnectionString);
            _customer = mongoClient.GetDatabase(options.Value.DatabaseName).GetCollection<customer>(options.Value.CollectionName);

        }

        public async Task<List<customer>> Get() =>
            await _customer.Find(_ => true).ToListAsync();

        public async Task<customer> Get(string id) =>
            await _customer.Find(m => m.Id == id).FirstOrDefaultAsync();


        public async Task  Create(customer newcustomer)=>
            await _customer.InsertOneAsync(newcustomer);


        public async Task Update( string id ,customer updatecustomer) =>
           await _customer.ReplaceOneAsync(m=>m.Id ==id, updatecustomer);

        public async Task Remove(string id)=>
             await _customer.DeleteOneAsync(m => m.Id == id);

    }
}
