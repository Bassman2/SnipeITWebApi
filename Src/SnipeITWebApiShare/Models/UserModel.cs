namespace SnipeITWebApi.Models;

internal class UserModel : BaseModel
{
    [JsonPropertyName("avatar")]
    public string? Avatar { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("password_confirmation")]
    public string? PasswordConfirmation { get; set; }
    
    [JsonPropertyName("remote")]
    public bool Remote { get; set; }

    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    [JsonPropertyName("employee_num")]
    public string? EmployeeNum { get; set; }

    [JsonPropertyName("manager")]
    public NamedItemModel? Manager { get; set; }

    [JsonPropertyName("jobtitle")]
    public string? Jobtitle { get; set; }

    [JsonPropertyName("vip")]
    public bool Vip { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("department")]
    public NamedItemModel? Department { get; set; }

    [JsonPropertyName("location")]
    public NamedItemModel? Location { get; set; }

    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionsJsonConverter))]
    public PermissionsModel? Permissions { get; set; }

    [JsonPropertyName("activated")]
    public bool? Activated { get; set; }

    [JsonPropertyName("autoassign_licenses")]
    public bool? AutoassignLicenses { get; set; }

    [JsonPropertyName("ldap_import")]
    public bool? LdapImport { get; set; }

    [JsonPropertyName("two_factor_enrolled")]
    public bool? TwoFactorEnrolled { get; set; }

    [JsonPropertyName("two_factor_optin")]
    public bool? TwoFactorOptin { get; set; }

    [JsonPropertyName("assets_count")]
    public int AssetsCount { get; set; }

    [JsonPropertyName("licenses_count")]
    public int LicensesCount { get; set; }

    [JsonPropertyName("accessories_count")]
    public int AccessoriesCount { get; set; }

    [JsonPropertyName("consumables_count")]
    public int ConsumablesCount { get; set; }

    [JsonPropertyName("manages_users_count")]
    public int ManagesUsersCount { get; set; }

    [JsonPropertyName("manages_locations_count")]
    public int ManagesLocationsCount { get; set; }

    [JsonPropertyName("company")]
    public NamedItemModel? Company { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? EndDate { get; set; }

    [JsonPropertyName("last_login")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? LastLogin { get; set; }

    [JsonPropertyName("groups")]
    [JsonConverter(typeof(ListJsonConverter))]
    public List<NamedItemModel>? Groups { get; set; }
}
