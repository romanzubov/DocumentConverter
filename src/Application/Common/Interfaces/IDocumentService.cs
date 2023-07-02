using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.ValueObjects;

namespace DocumentConverter.Application.Common.Interfaces;

public interface IDocumentService
{
    Task<Document> Create(string documentName, FileType fileType, Stream fileStream);
    void RemoveTempFile(Document document);
}