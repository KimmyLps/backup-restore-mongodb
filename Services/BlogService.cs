using backup_restore_mongodb.DTOs;
using backup_restore_mongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace backup_restore_mongodb.Services
{
    public class BlogsService
    {
        private readonly IMongoCollection<Blog> _blogsCollection;
        private readonly ILogger<BlogsService> _logger;

        public BlogsService(
            IOptions<StoreDatabaseSettings> StoreDatabaseSettings, ILogger<BlogsService> logger)
        {
            logger.LogInformation($"Connection String: {StoreDatabaseSettings.Value.ConnectionString}");
            var mongoClient = new MongoClient(
                StoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                StoreDatabaseSettings.Value.DatabaseName);

            _blogsCollection = mongoDatabase.GetCollection<Blog>(
                StoreDatabaseSettings.Value.BlogsCollectionName);
            _logger = logger;
        }

        public async Task<List<Blog>> GetAsync() =>
            await _blogsCollection.Find(_ => true).ToListAsync();

        public async Task<Blog?> GetAsync(string id) =>
            await _blogsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Blog newBlog) =>
            await _blogsCollection.InsertOneAsync(newBlog);

        public async Task UpdateAsync(string id, Blog updatedBlog) =>
            await _blogsCollection.ReplaceOneAsync(x => x.Id == id, updatedBlog);

        public async Task RemoveAsync(string id) =>
            await _blogsCollection.DeleteOneAsync(x => x.Id == id);
    }
}