namespace SnipeITWebApiUnitTest;

public static class RangeAssert
{
    public static void IsLessThan(long? expected, long? actual, string? message, [CallerMemberName] string memberName = "")
    {
        CheckNull(expected, actual, message);
        if (!(actual < expected))
        {
            throw new AssertFailedException($"RangeAssert.{memberName} failed. Actual:<{actual}> not {memberName} Expected:<{expected}>. {message}");
        }
    }

    public static void IsLessOrEqualThan(long? expected, long? actual, string? message, [CallerMemberName] string memberName = "")
    {
        CheckNull(expected, actual, message);
        if (!(actual <= expected))
        {
            throw new AssertFailedException($"RangeAssert.{memberName} failed. Actual:<{actual}> not {memberName} Expected:<{expected}>. {message}");
        }
    }

    public static void IsGreaterThan(long? expected, long? actual, string? message, [CallerMemberName] string memberName = "")
    {
        CheckNull(expected, actual, message);
        if (!(actual > expected))
        {
            throw new AssertFailedException($"RangeAssert.{memberName} failed. Actual:<{actual}> not {memberName} Expected:<{expected}>. {message}");
        }
    }

    public static void IsGreaterOrEqualThan(long? expected, long? actual, string? message, [CallerMemberName] string memberName = "")
    {
        CheckNull(expected, actual, message);
        if (!(actual <= expected))
        {
            throw new AssertFailedException($"RangeAssert.{memberName} failed. Actual:<{actual}> not {memberName} Expected:<{expected}>. {message}");
        }
    }

    public static void IsInRange(long? min, long? max, long? actual, string? message, [CallerMemberName] string memberName = "")
    {
        CheckNull(min, max, actual, message);
        if (actual < min || actual > max)
        {
            throw new AssertFailedException($"RangeAssert.{memberName} failed. Actual:<{actual}> is not in range  Minimum:<{min}> and Maximum:<{max}>. {message}");
        }
    }

    private static void CheckNull(long? expected, long? actual, string? message)
    {
        if (actual == null)
        {
            throw new AssertFailedException($"The actual value was null. {message}");
        }
        else if (expected == null)
        {
            throw new AssertFailedException($"The expected value was null. {message}");
        }
    }

    private static void CheckNull(long? min, long? max, long? actual, string? message)
    {
        if (actual == null)
        {
            throw new AssertFailedException($"The actual value was null. {message}");
        }
        else if (min == null)
        {
            throw new AssertFailedException($"The minimum value was null. {message}");
        }
        else if (max == null)
        {
            throw new AssertFailedException($"The exmaximum value was null. {message}");
        }
    }
}
