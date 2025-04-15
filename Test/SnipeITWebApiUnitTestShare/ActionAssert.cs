namespace SnipeITWebApiUnitTest;

public static class ActionAssert
{
    public static void AreEqual(AvailableActions? expected, AvailableActions? actual, string? message, [CallerMemberName] string memberName = "")
    {

        if (actual == null && expected == null)
        {
            return;
        }   

        if (actual == null)
        {
            throw new AssertFailedException($"The actual value was null. {message}");
        }

        if (expected == null)
        {
            throw new AssertFailedException($"The expected value was null. {message}");
        }

        if (expected.Checkout != actual.Checkout)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Checkout failed. Actual:<{actual.Checkout}> not {memberName} Expected:<{expected.Checkout}>. {message}");
        }
        if (expected.Checkin != actual.Checkin)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Checkin failed. Actual:<{actual.Checkin}> not {memberName} Expected:<{expected.Checkin}>. {message}");
        }
        if (expected.Clone != actual.Clone)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Clone failed. Actual:<{actual.Clone}> not {memberName} Expected:<{expected.Clone}>. {message}");
        }
        if (expected.Restore != actual.Restore)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Restore failed. Actual:<{actual.Restore}> not {memberName} Expected:<{expected.Restore}>. {message}");
        }
        if (expected.Update != actual.Update)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Update failed. Actual:<{actual.Update}> not {memberName} Expected:<{expected.Update}>. {message}");
        }
        if (expected.Delete != actual.Delete)
        {
            throw new AssertFailedException($"ActionAssert.{memberName} Delete failed. Actual:<{actual.Delete}> not {memberName} Expected:<{expected.Delete}>. {message}");
        }
    }
}
