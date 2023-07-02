using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.ValueObjects;

namespace DocumentConverter.Application.Common.Interfaces;

public interface IDocumentConverter
{
    HashSet<(FileType,FileType)> SupportedConversions { get; }
    bool CanConvert(FileType sourceFileType, FileType targetFileType);
    Task<Document> Convert(Document sourceDocument, FileType targetFileType);
}