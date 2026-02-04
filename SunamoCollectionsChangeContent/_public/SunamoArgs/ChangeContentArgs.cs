namespace SunamoCollectionsChangeContent._public.SunamoArgs;

/// <summary>
/// Configuration arguments for collection content transformation operations.
/// </summary>
public class ChangeContentArgs
{
    /// <summary>
    /// Gets or sets a value indicating whether empty strings should be removed from the result.
    /// </summary>
    public bool ShouldRemoveEmpty { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether null values should be removed from the result.
    /// </summary>
    public bool ShouldRemoveNull { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether the first and second arguments should be switched in the transformation function.
    /// </summary>
    public bool ShouldSwitchFirstAndSecondArg { get; set; } = false;

    /// <summary>
    /// Gets or sets a list of indexes that should not be changed during the transformation.
    /// </summary>
    public List<int>? DontChangeIndexes { get; set; } = null;
}