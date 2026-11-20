namespace SunamoCollectionsChangeContent._public.SunamoArgs;

/// <summary>
/// Represents the change content args type.
/// </summary>
public class ChangeContentArgs
{
    /// <summary>
    /// Gets or sets the should remove empty.
    /// </summary>
    public bool ShouldRemoveEmpty { get; set; } = false;

    /// <summary>
    /// Gets or sets the should remove null.
    /// </summary>
    public bool ShouldRemoveNull { get; set; } = false;

    /// <summary>
    /// Gets or sets the should switch first and second arg.
    /// </summary>
    public bool ShouldSwitchFirstAndSecondArg { get; set; } = false;

    /// <summary>
    /// Gets or sets the dont change indexes.
    /// </summary>
    public List<int>? DontChangeIndexes { get; set; } = null;
}
