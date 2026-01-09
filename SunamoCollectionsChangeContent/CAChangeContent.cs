// variables names: ok
namespace SunamoCollectionsChangeContent;

/// <summary>
/// Provides methods for modifying collections of strings with custom transformation functions.
/// </summary>
public class CAChangeContent
{
    /// <summary>
    /// Removes null or empty strings from the collection based on the provided arguments.
    /// </summary>
    /// <param name="args">Configuration arguments specifying whether to remove null or empty values.</param>
    /// <param name="items">The list of strings to process.</param>
    private static void RemoveNullOrEmpty(ChangeContentArgs? args, List<string?> items)
    {
        if (args != null)
        {
            if (args.ShouldRemoveNull) items.Remove(null);
            if (args.ShouldRemoveEmpty)
                for (var i = items.Count - 1; i >= 0; i--)
                    if (items[i]?.Trim() == string.Empty)
                        items.RemoveAt(i);
        }
    }

    /// <summary>
    /// Directly edits the collection by applying a transformation function to each element.
    /// The method name suffix indicates the number of additional parameters passed to the delegate (0 in this case).
    /// If not every element fulfills the pattern, it is good to remove null values from the result.
    /// </summary>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function to apply to each element.</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContent0(ChangeContentArgs? args, List<string?> items, Func<string?, string?> func)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(items[i]);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    /// <summary>
    /// Directly edits the collection by applying a transformation function with one additional argument to each element.
    /// The method name suffix indicates the number of additional parameters passed to the delegate (1 in this case).
    /// </summary>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function to apply to each element.</param>
    /// <param name="argument1">The first argument to pass to the transformation function.</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContent1<T>(ChangeContentArgs? args, List<string?> items,
        Func<string?, T, string?> func, T argument1)
    {
        return ChangeContent(args, items, func, argument1);
    }

    /// <summary>
    /// Directly edits the collection by applying a transformation function with two additional arguments to each element.
    /// The method name suffix indicates the number of additional parameters passed to the delegate (2 in this case).
    /// </summary>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function to apply to each element.</param>
    /// <param name="argument1">The first argument to pass to the transformation function.</param>
    /// <param name="argument2">The second argument to pass to the transformation function.</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContent2<T, U>(ChangeContentArgs? args, List<string?> items,
        Func<string?, T, U, string?> func, T argument1, U argument2)
    {
        for (var i = 0; i < items.Count; i++)
        {
            if (args != null && args.DontChangeIndexes != null && args.DontChangeIndexes.Contains(i))
            {
                continue;
            }
            items[i] = func.Invoke(items[i], argument1, argument2);
        }
        RemoveNullOrEmpty(args, items);
        return items;
    }

    /// <summary>
    /// Directly edits the collection by applying a transformation function only to elements that satisfy the predicate.
    /// Earlier name was ChangeContent, but has Predicate parameter, hence the name ChangeContentWithCondition.
    /// </summary>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="predicate">The condition that determines which elements to transform.</param>
    /// <param name="func">The transformation function to apply to matching elements.</param>
    /// <returns>True if any element was changed, false otherwise.</returns>
    public static bool ChangeContentWithCondition(ChangeContentArgs? args, List<string?> items,
        Predicate<string?> predicate, Func<string?, string?> func)
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

    #region Both function variants

    /// <summary>
    /// Changes the content of the collection by applying a transformation function with switched parameter order.
    /// The function receives the argument first, then the string element.
    /// </summary>
    /// <typeparam name="Arg1">The type of the argument to pass to the transformation function.</typeparam>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function with switched parameter order (argument first, then string).</param>
    /// <param name="argument">The argument to pass to the transformation function.</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContentSwitch12<Arg1>(List<string?> items, Func<Arg1, string?, string?> func,
        Arg1 argument)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(argument, items[i]);
        return items;
    }

    /// <summary>
    /// Directly edits the input collection by applying a transformation function.
    /// Supports both normal parameter order and switched parameter order via the funcSwitch12 parameter.
    /// </summary>
    /// <typeparam name="Arg1">The type of the argument to pass to the transformation function.</typeparam>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function with normal parameter order (string first, then argument).</param>
    /// <param name="argument">The argument to pass to the transformation function.</param>
    /// <param name="funcSwitch12">Optional transformation function with switched parameter order (argument first, then string).</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContent<Arg1>(ChangeContentArgs? args, List<string?> items,
        Func<string?, Arg1, string?> func, Arg1 argument, Func<Arg1, string?, string?>? funcSwitch12 = null)
    {
        if (args == null) args = new ChangeContentArgs();
        if (args.ShouldSwitchFirstAndSecondArg)
            items = ChangeContentSwitch12(items, funcSwitch12!, argument);
        else
            for (var i = 0; i < items.Count; i++)
                items[i] = func.Invoke(items[i], argument);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    #endregion

    #region ChangeContent for easy copy


    /// <summary>
    /// Directly edits the collection by applying a transformation function with two arguments to each element.
    /// This overload is provided for convenience when working with two generic argument types.
    /// </summary>
    /// <typeparam name="Arg1">The type of the first argument to pass to the transformation function.</typeparam>
    /// <typeparam name="Arg2">The type of the second argument to pass to the transformation function.</typeparam>
    /// <param name="args">Configuration arguments for the transformation.</param>
    /// <param name="items">The list of strings to transform.</param>
    /// <param name="func">The transformation function to apply to each element.</param>
    /// <param name="argument1">The first argument to pass to the transformation function.</param>
    /// <param name="argument2">The second argument to pass to the transformation function.</param>
    /// <returns>The modified list of strings.</returns>
    public static List<string?> ChangeContent<Arg1, Arg2>(ChangeContentArgs? args, List<string?> items,
        Func<string?, Arg1, Arg2, string?> func, Arg1 argument1, Arg2 argument2)
    {
        for (var i = 0; i < items.Count; i++) items[i] = func.Invoke(items[i], argument1, argument2);
        RemoveNullOrEmpty(args, items);
        return items;
    }

    #endregion
}