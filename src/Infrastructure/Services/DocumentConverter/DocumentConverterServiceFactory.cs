using DocumentConverter.Application.Common.Interfaces;
using DocumentConverter.Domain.Enums;
using DocumentConverter.Infrastructure.Services.DocumentConverter.Backends;
using Microsoft.Extensions.Configuration;

namespace DocumentConverter.Infrastructure.Services.DocumentConverter;

public class DocumentConverterServiceFactory
{
    public IDocumentConverter DefaultDocumentConverter { get; init; }
    
    public DocumentConverterServiceFactory(IConfiguration configuration)
    {
        var defaultConversionBackend = configuration["DefaultConversionBackend"];

        DefaultDocumentConverter = Create(defaultConversionBackend);
    }
    
    public IDocumentConverter Create(DocumentConversionBackend conversionBackend) => conversionBackend switch
    {
        DocumentConversionBackend.LibreOffice => new LibreOfficeConverter(),
        DocumentConversionBackend.MsOffice => new MsOfficeConverter(),
        _ => DefaultDocumentConverter
    };
    
    private IDocumentConverter Create(string? conversionBackend) => conversionBackend switch
    {
        "LibreOffice" => new LibreOfficeConverter(),
        "MsOffice" => new MsOfficeConverter(), 
        _ => new LibreOfficeConverter()
    };
}