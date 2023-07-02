using DocumentConverter.Application.Common.Interfaces;
using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;

namespace DocumentConverter.Infrastructure.Services;

public class DocumentService : IDocumentService
{
    private readonly string _tempFolder;
    
    public DocumentService(IConfiguration configuration)
    {
        _tempFolder = configuration["TempFolder"] ?? Path.GetTempPath();
    }
    
    public async Task<Document> Create(string documentName, FileType fileType, Stream fileStream)
    {
        var id = Guid.NewGuid();
        
        var path = Path.Combine(_tempFolder, id.ToString());

        var document = new Document
        (
            id,
            fileType,
            Path.GetFileNameWithoutExtension(documentName),
            path
        );

        await using var file = File.Create(path, 1024);
        fileStream.Seek(0, SeekOrigin.Begin);
        await fileStream.CopyToAsync(file);

        return document;
    }

    public void RemoveTempFile(Document document)
    {
        if(File.Exists(document.TempFilePath))
            File.Delete(document.TempFilePath);
    }
}