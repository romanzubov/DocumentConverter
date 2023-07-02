namespace DocumentConverter.Domain.ValueObjects;

public class FileType : ValueObject
{
    public string Code { get; private set; } = "None";
    
    private FileType()
    {
    }
    
    private FileType(string code)
    {
        Code = code;
    }

    
    public static FileType From(string code)
    {
        var fileType = new FileType { Code = code };

        if (!SupportedFileTypes.Contains(fileType))
        {
            throw new UnsupportedFileTypeException(code);
        }

        return fileType;
    }
    
    
    public static FileType Doc => new(".doc");

    public static FileType Docx => new(".docx");

    public static FileType Xls => new("xls");

    public static FileType Xlsx => new(".xlsx");

    public static FileType Pdf => new(".pdf");

    public static FileType Html => new(".html");

    public static FileType Png => new(".png");
    public static FileType Ttf => new(".ttf");

    protected static IEnumerable<FileType> SupportedFileTypes
    {
        get
        {
            yield return Doc;
            yield return Docx;
            yield return Xls;
            yield return Xlsx;
            yield return Pdf;
            yield return Html;
            yield return Png;
            yield return Ttf;
        }
    }
    
    public static implicit operator string(FileType fileType)
    {
        return fileType.ToString() ?? string.Empty;
    }
    
    public static explicit operator FileType(string code)
    {
        return From(code);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }
}