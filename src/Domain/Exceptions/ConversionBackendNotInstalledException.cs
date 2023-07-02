using DocumentConverter.Domain.Enums;

namespace DocumentConverter.Application.Common.Exceptions;

public class ConversionBackendNotInstalledException : Exception
{
    public ConversionBackendNotInstalledException(DocumentConversionBackend backend)
        : base($"Document conversion backend \"{backend}\" not installed or not supported on target os platform!")
    { }
}