namespace SnipeITWebApiUnitTest;

public static class DateTimeAssert
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
            throw new AssertFailedException($"DateTimeAssert.AreEqual failed. Expected:<{expected}>. Actual:<{val}>. {message}");
        }
    }
}
