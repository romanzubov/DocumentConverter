using CliWrap;
using DocumentConverter.Application.Common.Exceptions;
using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.Enums;
using DocumentConverter.Domain.ValueObjects;
using DocumentConverter.Domain.Exceptions;
namespace DocumentConverter.Infrastructure.Services.DocumentConverter.Backends;

public class LibreOfficeConverter : BaseDocumentConverter
{
    public override HashSet<(FileType, FileType)> SupportedConversions => new()
    {
        (FileType.Doc, FileType.Docx),
        (FileType.Doc, FileType.Pdf),
        (FileType.Doc, FileType.Html),
        (FileType.Doc, FileType.Xls),
        (FileType.Doc, FileType.Xlsx),
        (FileType.Doc, FileType.Png),
        (FileType.Doc, FileType.Pdf),
        
        (FileType.Docx, FileType.Doc),
        (FileType.Docx, FileType.Pdf),
        (FileType.Docx, FileType.Html),
        (FileType.Docx, FileType.Xls),
        (FileType.Docx, FileType.Xlsx),
        (FileType.Docx, FileType.Png),
        (FileType.Docx, FileType.Pdf),
        
        (FileType.Xls, FileType.Xlsx),
        (FileType.Xls, FileType.Pdf),
        (FileType.Xls, FileType.Doc),
        (FileType.Xls, FileType.Docx),
        (FileType.Xls, FileType.Png),
        (FileType.Xls, FileType.Pdf),
        (FileType.Xls, FileType.Html),
        
        (FileType.Xlsx, FileType.Xls),
        (FileType.Xlsx, FileType.Pdf),
        (FileType.Xlsx, FileType.Doc),
        (FileType.Xlsx, FileType.Docx),
        (FileType.Xlsx, FileType.Png),
        (FileType.Xlsx, FileType.Pdf),
        (FileType.Xlsx, FileType.Html)
    };
    
    public async override Task<Document> Convert(Document sourceDocument, FileType targetFileType)
    {
        if (!await IsBackendPresentInTargetSystem())
            throw new ConversionBackendNotInstalledException(DocumentConversionBackend.LibreOffice);
        
        if (!CanConvert(sourceDocument.FileType, targetFileType))
            throw new ConversionNotSupportedException(sourceDocument.FileType, targetFileType);

        return null;
    }

    protected async override Task<bool> IsBackendPresentInTargetSystem()
    {
        var result = await Cli.Wrap("soffice").WithArguments("--version")
            .ExecuteAsync();

        return result.ExitCode == 0;
    }
}