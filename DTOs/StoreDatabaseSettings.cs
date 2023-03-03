namespace backup_restore_mongodb.DTOs;

public class StoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string BooksCollectionName { get; set; } = null!;

    public string BlogsCollectionName { get; set; } = null!;
}