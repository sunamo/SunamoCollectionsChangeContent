namespace SunamoCollectionsChangeContent._sunamo.SunamoExceptions;

/// <summary>
/// Partial class for exception handling and additional information storage.
/// </summary>
internal sealed partial class Exceptions
{
    /// <summary>
    /// String builder for inner additional information in exception messages.
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();

    /// <summary>
    /// String builder for additional information in exception messages.
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();
}