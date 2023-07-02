using System.Runtime.Versioning;
using System.Runtime.InteropServices;

using CliWrap;

using DocumentConverter.Domain.Enums;
using DocumentConverter.Domain.Entities;
using DocumentConverter.Domain.Exceptions;
using DocumentConverter.Domain.ValueObjects;
using DocumentConverter.Application.Common.Exceptions;

namespace DocumentConverter.Infrastructure.Services.DocumentConverter.Backends;

[SupportedOSPlatform("windows")]
public class MsOfficeConverter : BaseDocumentConverter
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

    public override async Task<Document> Convert(Document sourceDocument, FileType targetFileType)
    {
        if (!await IsBackendPresentInTargetSystem())
            throw new ConversionBackendNotInstalledException(DocumentConversionBackend.MsOffice);

        if (!CanConvert(sourceDocument.FileType, targetFileType))
            throw new ConversionNotSupportedException(sourceDocument.FileType, targetFileType);
        
        return null;
    }

    protected override async Task<bool> IsBackendPresentInTargetSystem()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            return false;

        var wordResult = await Cli.Wrap("powershell").WithArguments("(New-Object -ComObject Word.Application).Version")
            .ExecuteAsync();
        var excelResult = await Cli.Wrap("powershell").WithArguments("(New-Object -ComObject Excel.Application).Version")
            .ExecuteAsync();
        
        return wordResult.ExitCode == 0 && excelResult.ExitCode == 0;
    }
}