using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTeste.Infra.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle SessionHandle { get; set; }
        public MongoClient MongoClient { get; set; }


        private IConfiguration _configuration;
        private readonly List<Func<Task>> _commands;

        public MongoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();
        }

        public async Task<int> SaveChangesAsync()
        {
            ConfigureMongo();

            using (SessionHandle = await MongoClient.StartSessionAsync())
            {
                SessionHandle.StartTransaction();

                var commandsTasks = _commands.Select(func => func());

                await Task.WhenAll(commandsTasks);

                await SessionHandle.CommitTransactionAsync();
            }
            return _commands.Count;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            ConfigureMongo();

            return Database.GetCollection<T>(name);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void Dispose()
        {
            SessionHandle?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void ConfigureMongo()
        {
            if (MongoClient != default)
                return;

            MongoClient = new MongoClient(_configuration["MongoSettings:Connection"]);
            Database = MongoClient.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
        }
    }
}
