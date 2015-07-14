using System.Collections.Generic;
using System;
using System.Linq;

public static class EnumHelpers
{
    public static IEnumerable<T> GetValues<T>() where T : IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new NotEnumException();

        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}

public class NotEnumException : Exception
{
}