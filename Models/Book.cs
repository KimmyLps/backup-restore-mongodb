using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace backup_restore_mongodb.Models
{
    public class Book
    {
        public Book()
        {
            Id = Guid.NewGuid().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("name")]
        [JsonProperty("name")]
        public string BookName { get; set; } = null!;

        [BsonElement("price")]
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [BsonElement("category")]
        [JsonProperty("category")]
        public string Category { get; set; } = null!;

        [BsonElement("author")]
        [JsonProperty("author")]
        public string Author { get; set; } = null!;
    }
}