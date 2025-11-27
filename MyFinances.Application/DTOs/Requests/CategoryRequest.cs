namespace MyFinances.Application.DTOs.Requests;

public class CategoryRequest
{
    
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    
    public int? ParentCategoryId { get; set; }
}