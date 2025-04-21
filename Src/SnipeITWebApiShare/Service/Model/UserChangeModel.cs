namespace SnipeITWebApi.Service.Model;

internal class UserChangeModel : BaseChangeModel
{
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

    [JsonPropertyName("email")]
    public string? Email { get; set; }
        
    [JsonPropertyName("activated")]
    public bool? Activated { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("jobtitle")]
    public string? Jobtitle { get; set; }

    [JsonPropertyName("manager_id")]
    public int? ManagerId { get; set; }

    [JsonPropertyName("employee_num")]
    public string? EmployeeNum { get; set; }

    [JsonPropertyName("company_id")]
    public int? CompanyId { get; set; }

    [JsonPropertyName("two_factor_enrolled")]
    public bool? TwoFactorEnrolled { get; set; }

    [JsonPropertyName("two_factor_optin")]
    public bool? TwoFactorOptin { get; set; }

    [JsonPropertyName("department_id")]
    public int? DepartmentId { get; set; }

    [JsonPropertyName("location_id")]
    public int? LocationId { get; set; }

    [JsonPropertyName("remote")]
    public bool? Remote { get; set; }

    [JsonPropertyName("groups")]
    [JsonConverter(typeof(ListJsonConverter))]
    public List<NamedItemModel>? Groups { get; set; }

    [JsonPropertyName("autoassign_licenses")]
    public bool? AutoassignLicenses { get; set; }

    [JsonPropertyName("vip")]
    public bool? Vip { get; set; }

    [JsonPropertyName("start_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    [JsonConverter(typeof(DateJsonConverter))]
    public DateTime? EndDate { get; set; }
}
