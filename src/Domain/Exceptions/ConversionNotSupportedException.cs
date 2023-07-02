namespace DocumentConverter.Domain.Exceptions;

public class ConversionNotSupportedException : Exception
{
    public ConversionNotSupportedException(FileType sourceFileType, FileType targetFileType) 
        : base($"Conversion from \"{sourceFileType}\" to \"{targetFileType}\" not supported!")
    { }
}