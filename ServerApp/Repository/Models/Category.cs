namespace family_tasks.Repository.Models;

public class Category
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public const string DefaultColorHexCode = "#dff6dd";
    private string? _colorHexCode;
    public string? ColorHexCode
    {
        get { return _colorHexCode ?? DefaultColorHexCode; }
        set { _colorHexCode = value; }
    }
}