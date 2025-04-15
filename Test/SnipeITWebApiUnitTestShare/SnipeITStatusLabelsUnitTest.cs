namespace SnipeITWebApiUnitTest;

[TestClass]
public class SnipeITStatusLabelsUnitTest : SnipeITBaseUnitTest<StatusLabel>
{
    public SnipeITStatusLabelsUnitTest()
    {
        create = new StatusLabel()
        {
            Name = CreateName(),
            Type = StatusType.pending,
            //Image = imageCreate,    
            Notes = "create",
        };

        update = new StatusLabel()
        {
            Name = CreateName(),
            Type = StatusType.archived,
            //Image = imageUpdate,
            Notes = notesUpdate,
        };

        patch = new StatusLabel()
        {
            Name = CreateName(),
            Type = StatusType.deployable,
            //Image = imageUpdate,
            Notes = notesPatch,
        };
    }

    public override void AreEqual(StatusLabel expected, StatusLabel actual, string message)
    {
        //Assert.AreEqual(expected.Type, actual.Type, $"{message}.Type");
        Assert.AreEqual(expected.Color, actual.Color, $"{message}.Color");
        Assert.AreEqual(expected.ShowInNav ?? false, actual.ShowInNav, $"{message}.ShowInNav");
        Assert.AreEqual(expected.DefaultLabel ?? false, actual.DefaultLabel, $"{message}.DefaultLabel");
        //Assert.AreEqual(0, actual.AssetsCount ?? 0, $"{message}.AssetsCount");
    }

    public override IAsyncEnumerable<StatusLabel> GetAsync(SnipeIT snipeIT)
        => snipeIT.GetStatusLabelsAsync();

    public override async Task<StatusLabel?> GetAsync(SnipeIT snipeIT, int id)
        => await snipeIT.GetStatusLabelAsync(id);

    public override async Task<int> CreateAsync(SnipeIT snipeIT, StatusLabel value)
        => await snipeIT.CreateStatusLabelAsync(value);

    public override async Task UpdateAsync(SnipeIT snipeIT, int id, StatusLabel value)
        => await snipeIT.UpdateStatusLabelAsync(id, value);

    public override async Task PatchAsync(SnipeIT snipeIT, int id, StatusLabel value)
        => await snipeIT.PatchStatusLabelAsync(id, value);

    public override async Task DeleteAsync(SnipeIT snipeIT, int id)
        => await snipeIT.DeleteStatusLabelAsync(id);
}
