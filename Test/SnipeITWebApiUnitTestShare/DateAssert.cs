namespace SnipeITWebApiUnitTest;

public static class DateAssert
{
    public static void AreEqual(string? expected, DateTime? actual, string? message)
    {
        if (expected == null && actual == null)
        {
            return;
        }
        else if (expected == null)
        {
            throw new AssertFailedException($"The expected date was null. {message}");
        }
        else if (actual == null)
        {
            throw new AssertFailedException($"The actual date was null. {message}");
        }
        string val = actual.Value.ToString("yyyy-MM-dd");
        if (expected != val)
        {
            // Assert.AreEqual failed. Expected:<1 : Computer Depreciation>. Actual:<1 : Demo Account>. item.CreatedBy
            throw new AssertFailedException($"DateAssert.AreEqual failed. Expected:<{expected}>. Actual:<{val}>. {message}");
        }
    }

    public static void AreEqual(DateTime? expected, DateTime? actual, string? message)
    {
        if (expected == null && actual == null)
        {
            return;
        }
        else if (expected == null)
        {
            throw new AssertFailedException($"The expected date was null. {message}");
        }
        else if (actual == null)
        {
            throw new AssertFailedException($"The actual date was null. {message}");
        }
        if (expected.Value.Date != actual.Value.Date)
        {
            // Assert.AreEqual failed. Expected:<1 : Computer Depreciation>. Actual:<1 : Demo Account>. item.CreatedBy
            throw new AssertFailedException($"DateAssert.AreEqual failed. Expected:<{expected}>. Actual:<{actual}>. {message}");
        }
    }

    public static void IsNull(DateTime? actual, string? message)
    {
        if (actual == null)
        {
            throw new AssertFailedException($"DateAssert.IsNull failed. Expected:<null>. Actual:<{actual}>. {message}");
        }
    }
}
