using System.Diagnostics.CodeAnalysis;

namespace DeepLClient.Enums;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public enum DocumentType
{
    Word,
    PowerPoint,
    PDF,
    Text,
    HTML,
    Unsupported
}