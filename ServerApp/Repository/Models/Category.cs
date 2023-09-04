namespace family_tasks.Repository.Models;

public class Category
{
    public const string DefaultColorHexCode = "5AAB61";

    public int Id { get; set; }

    public required string Name { get; set; }

    private string? _colorHexCode;
    public string? ColorHexCode
    {
        get
        {
            return _colorHexCode ?? DefaultColorHexCode;
        }
        set
        {
            _colorHexCode = value;
        }
    }
}