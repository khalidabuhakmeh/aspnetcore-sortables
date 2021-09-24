namespace Sortables.Models;

public class GroceryList
{
    public List<GroceryItem> Items { get; set; }
        = new();
}

public class GroceryItem
{
    public string Name { get; set; } = "";
    public int Amount { get; set; }
}