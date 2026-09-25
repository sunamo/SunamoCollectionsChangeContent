namespace SunamoCollectionsChangeContent;

public class CAChangeContent
{
    private static void removeNullOrEmpty(ChangeContentArgs? args, List<string?> list)
    {
        if (args != null)
        {
            if (args.ShouldRemoveNull) list.Remove(null);
            if (args.ShouldRemoveEmpty)
                for (var i = list.Count - 1; i >= 0; i--)
                    if (list[i]?.Trim() == string.Empty)
                        list.RemoveAt(i);
        }
    }

    public static List<string?> ChangeContent0(ChangeContentArgs? args, List<string?> list, Func<string?, string?> func)
    {
        for (var i = 0; i < list.Count; i++) list[i] = func.Invoke(list[i]);
        removeNullOrEmpty(args, list);
        return list;
    }

    public static List<string?> ChangeContent1<TArg>(ChangeContentArgs? args, List<string?> list,
        Func<string?, TArg, string?> func, TArg argument1)
    {
        return ChangeContent(args, list, func, argument1);
    }

    public static List<string?> ChangeContent2<TArg1, TArg2>(ChangeContentArgs? args, List<string?> list,
        Func<string?, TArg1, TArg2, string?> func, TArg1 argument1, TArg2 argument2)
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (args != null && args.DontChangeIndexes != null && args.DontChangeIndexes.Contains(i))
            {
                continue;
            }
            list[i] = func.Invoke(list[i], argument1, argument2);
        }
        removeNullOrEmpty(args, list);
        return list;
    }

    public static bool ChangeContentWithCondition(ChangeContentArgs? args, List<string?> list,
        Predicate<string?> predicate, Func<string?, string?> func)
    {
        var changed = false;
        for (var i = 0; i < list.Count; i++)
            if (predicate.Invoke(list[i]))
            {
                list[i] = func.Invoke(list[i]);
                changed = true;
            }

        removeNullOrEmpty(args, list);
        return changed;
    }

    #region Both function variants

    public static List<string?> ChangeContentSwitch12<TArg>(List<string?> list, Func<TArg, string?, string?> func,
        TArg argument)
    {
        for (var i = 0; i < list.Count; i++) list[i] = func.Invoke(argument, list[i]);
        return list;
    }

    public static List<string?> ChangeContent<TArg>(ChangeContentArgs? args, List<string?> list,
        Func<string?, TArg, string?> func, TArg argument, Func<TArg, string?, string?>? funcSwitch12 = null)
    {
        if (args == null) args = new ChangeContentArgs();
        if (args.ShouldSwitchFirstAndSecondArg)
            list = ChangeContentSwitch12(list, funcSwitch12!, argument);
        else
            for (var i = 0; i < list.Count; i++)
                list[i] = func.Invoke(list[i], argument);
        removeNullOrEmpty(args, list);
        return list;
    }

    #endregion

    #region ChangeContent for easy copy

    public static List<string?> ChangeContent<TArg1, TArg2>(ChangeContentArgs? args, List<string?> list,
        Func<string?, TArg1, TArg2, string?> func, TArg1 argument1, TArg2 argument2)
    {
        for (var i = 0; i < list.Count; i++) list[i] = func.Invoke(list[i], argument1, argument2);
        removeNullOrEmpty(args, list);
        return list;
    }

    #endregion
}
