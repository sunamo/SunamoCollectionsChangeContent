// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollectionsChangeContent._public.SunamoArgs;

public class ChangeContentArgs
{
    public bool ShouldRemoveEmpty = false;
    public bool ShouldRemoveNull = false;
    public bool ShouldSwitchFirstAndSecondArg = false;
    public List<int> DontChangeIndexes = null;
}