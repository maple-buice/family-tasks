namespace family_tasks.Repository.Models;

public class FamilyMember
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public const string DefaultColorHexCode = "#efd9fd";
    private string? _colorHexCode;
    public string? ColorHexCode
    {
        get { return _colorHexCode ?? DefaultColorHexCode; }
        set { _colorHexCode = value; }
    }
}