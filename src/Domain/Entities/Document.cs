namespace DocumentConverter.Domain.Entities;

public class Document : BaseAuditableEntity<Guid>
{
    public Document(Guid id, FileType fileType, string name, string tempFilePath)
    {
        Id = id;
        FileType = fileType;
        Name = name;
        TempFilePath = tempFilePath;
    }

    public string Name { get; init; }
    public string TempFilePath { get; init; }
    public FileType FileType { get; init; }
}