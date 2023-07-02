namespace DocumentConverter.Domain.Exceptions;

public class UnsupportedFileTypeException : Exception
{
    public UnsupportedFileTypeException(string code)
        : base($"FileType \"{code}\" is unsupported.")
    {
    }
}
