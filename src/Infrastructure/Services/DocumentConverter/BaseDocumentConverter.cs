using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.ValueObjects;
using DocumentConverter.Application.Common.Interfaces;

namespace DocumentConverter.Infrastructure.Services.DocumentConverter;

public abstract class BaseDocumentConverter : IDocumentConverter
{
    public abstract HashSet<(FileType, FileType)> SupportedConversions { get; }

    public bool CanConvert(FileType sourceFileType, FileType targetFileType) => 
        SupportedConversions.Contains((sourceFileType, targetFileType));
    public abstract Task<Document> Convert(Document sourceDocument, FileType targetFileType);
    protected abstract Task<bool> IsBackendPresentInTargetSystem();
}