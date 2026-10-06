namespace SunamoCollectionsChangeContent._public.SunamoArgs;

public class ChangeContentArgs
{
    public bool ShouldRemoveEmpty { get; set; } = false;

    public bool ShouldRemoveNull { get; set; } = false;

    public bool ShouldSwitchFirstAndSecondArg { get; set; } = false;

    public List<int>? DontChangeIndexes { get; set; } = null;
}
