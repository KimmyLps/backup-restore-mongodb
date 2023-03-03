using backup_restore_mongodb.DTOs;
using backup_restore_mongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backup_restore_mongodb.Services
{
    public class BooksService
    {
        private readonly IMongoCollection<Book> _booksCollection;
        private readonly ILogger<BooksService> _logger;

        public BooksService(
            IOptions<StoreDatabaseSettings> StoreDatabaseSettings, ILogger<BooksService> logger)
        {
            logger.LogInformation($"Connection String: {StoreDatabaseSettings.Value.ConnectionString}");
            var mongoClient = new MongoClient(
                StoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                StoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Book>(
                StoreDatabaseSettings.Value.BooksCollectionName);
            _logger = logger;
        }

        public async Task<List<Book>> GetAsync() =>
            await _booksCollection.Find(_ => true).ToListAsync();

        public async Task<Book?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Book newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Book updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}