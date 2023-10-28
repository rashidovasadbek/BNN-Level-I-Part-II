namespace FileUpload.Models.Entities;

public class StorageFile
{
    public Guid Id { get; set; }
    
    public string OrginalName { get; set; } = string.Empty;
    
    public string Path { get; set; } = string.Empty;
    
    public DateTime UploadAt { get; set; }
    
    public Guid UserId { get; set; }
}