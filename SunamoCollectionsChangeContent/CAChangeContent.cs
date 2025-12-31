namespace SunamoCollectionsChangeContent;

public class CAChangeContent
{
    private static void RemoveNullOrEmpty(ChangeContentArgs args, List<string> items)
    {
        if (args != null)
        {
            if (args.ShouldRemoveNull) items.Remove(null);
            if (args.ShouldRemoveEmpty)
                for (var i = items.Count - 1; i >= 0; i--)
                    if (items[i].Trim() == string.Empty)
                        items.RemoveAt(i);
        }
    }

    /// <summary>
    ///     Direct edit
    ///     If not every element fullfil pattern, is good to remove null (or values returned if cant be changed) from result
    ///     Poslední číslo je počet parametrů jež se předávají do delegátu
    /// </summary>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="func"></param>
    public static List<string> ChangeContent0(ChangeContentArgs args, List<string> items, Func<string, string> func)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(items[i]);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    /// <summary>
    ///     Direct edit
    ///     Poslední číslo je počet parametrů jež se předávají do delegátu
    /// </summary>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="func"></param>
    /// <param name="argument1"></param>
    /// <returns></returns>
    public static List<string> ChangeContent1<T>(ChangeContentArgs args, List<string> items,
        Func<string, T, string> func, T argument1)
    {
        return ChangeContent(args, items, func, argument1);
    }

    /// <summary>
    ///     Poslední číslo je počet parametrů jež se předávají do delegátu
    /// </summary>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="func"></param>
    /// <param name="argument1"></param>
    /// <param name="argument2"></param>
    /// <returns></returns>
    public static List<string> ChangeContent2<T, U>(ChangeContentArgs args, List<string> items,
        Func<string, T, U, string> func, T argument1, U argument2)
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (args.DontChangeIndexes != null && args.DontChangeIndexes.Contains(i))
            {
                continue;
            }
            items[i] = func.Invoke(items[i], argument1, argument2);
        }
        RemoveNullOrEmpty(args, items);
        return items;
    }

    /// <summary>
    ///     Direct edit
    ///     Earlier name was ChangeContent , but has Predicate => ChangeContentWithCondition
    /// </summary>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="predicate"></param>
    /// <param name="func"></param>
    public static bool ChangeContentWithCondition(ChangeContentArgs args, List<string> items,
        Predicate<string> predicate, Func<string, string> func)
    {
        var changed = false;
        for (var i = 0; i < items.Count; i++)
            if (predicate.Invoke(items[i]))
            {
                items[i] = func.Invoke(items[i]);
                changed = true;
            }

        RemoveNullOrEmpty(args, items);
        return changed;
    }

    #region Vem obojí

    public static List<string> ChangeContentSwitch12<Arg1>(List<string> items, Func<Arg1, string, string> func,
        Arg1 argument)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(argument, items[i]);
        return items;
    }

    /// <summary>
    ///     Direct edit input collection
    ///     Dříve to bylo List<string> files_in, Func<string,
    /// </summary>
    /// <typeparam name="Arg1"></typeparam>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="func"></param>
    /// <param name="argument"></param>
    /// <param name="funcSwitch12"></param>
    public static List<string> ChangeContent<Arg1>(ChangeContentArgs args, List<string> items,
        Func<string, Arg1, string> func, Arg1 argument, Func<Arg1, string, string> funcSwitch12 = null)
    {
        if (args == null) args = new ChangeContentArgs();
        if (args.ShouldSwitchFirstAndSecondArg)
            items = ChangeContentSwitch12(items, funcSwitch12, argument);
        else
            for (var i = 0; i < items.Count; i++)
                items[i] = func.Invoke(items[i], argument);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    #endregion

    #region ChangeContent for easy copy

 
    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <typeparam name="Arg1"></typeparam>
    /// <typeparam name="Arg2"></typeparam>
    /// <param name="args"></param>
    /// <param name="items"></param>
    /// <param name="func"></param>
    /// <param name="argument1"></param>
    /// <param name="argument2"></param>
    public static List<string> ChangeContent<Arg1, Arg2>(ChangeContentArgs args, List<string> items,
        Func<string, Arg1, Arg2, string> func, Arg1 argument1, Arg2 argument2)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(items[i], argument1, argument2);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    #endregion
}