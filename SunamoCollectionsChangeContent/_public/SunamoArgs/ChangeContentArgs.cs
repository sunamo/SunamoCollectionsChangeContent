namespace SunamoCollectionsChangeContent._public.SunamoArgs;

public class ChangeContentArgs
{
    public bool ShouldRemoveEmpty = false;
    public bool ShouldRemoveNull = false;
    public bool ShouldSwitchFirstAndSecondArg = false;
    public List<int> DontChangeIndexes = null;
}