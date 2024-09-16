namespace SetupService.ImportDefaultPermissions.Dto
{
    public class PermissionsDto
    {
        public string? Route { get; set; }
        public required List<string> Roles { get; set; }
    }
}
