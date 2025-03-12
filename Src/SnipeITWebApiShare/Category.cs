namespace SnipeITWebApi;

public class Category
{
    internal Category(CategoryModel model)
    {
        Id = model.Id;
        Name = model.Name;
        Image = model.Image;
        CategoryType = model.CategoryType;
        HasEula = model.HasEula;
        UseDefaultEula = model.UseDefaultEula;
        Eula = model.Eula;
        CheckinEmail = model.CheckinEmail;
        RequireAcceptance = model.RequireAcceptance;
        ItemCount = model.ItemCount;
        AssetsCount = model.AssetsCount;
        AccessoriesCount = model.AccessoriesCount;
        ConsumablesCount = model.ConsumablesCount;
        ComponentsCount = model.ComponentsCount;
        LicensesCount = model.LicensesCount;
        CreatedBy = model.CreatedBy.CastModel<Item>();
        Notes = model.Notes;
        CreatedAt = model.CreatedAt.CastModel<DateItem>();
        UpdatedAt = model.UpdatedAt.CastModel<DateItem>();
        AvailableActions = model.AvailableActions.CastModel<Actions>();
    }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public string? CategoryType { get; set; }

    public bool HasEula { get; set; }

    public bool UseDefaultEula { get; set; }

    public string? Eula { get; set; }

    public bool CheckinEmail { get; set; }

    public bool RequireAcceptance { get; set; }

    public int ItemCount { get; set; }

    public int AssetsCount { get; set; }

    public int AccessoriesCount { get; set; }

    public int ConsumablesCount { get; set; }

    public int ComponentsCount { get; set; }

    public int LicensesCount { get; set; }

    public Item? CreatedBy { get; set; }

    public string? Notes { get; set; }

    public DateItem? CreatedAt { get; set; }

    public DateItem? UpdatedAt { get; set; }

    public Actions? AvailableActions { get; set; }
}
