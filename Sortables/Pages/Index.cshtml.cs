using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sortables.Models;

namespace Sortables.Pages;

public class IndexModel : PageModel
{
    public static GroceryList Data = new GroceryList
    {
        Items = new List<GroceryItem>
        {
            new() {Name = "Bread", Amount = 1},
            new() {Name = "Milk", Amount = 2},
            new() {Name = "Bananas", Amount = 3}
        }
    };
    
    private readonly ILogger<IndexModel> _logger;

    [BindProperty]
    public GroceryList GroceryList { get; set; }
        = Data;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        Data = GroceryList;
        return RedirectToPage("Index");
    }

    public IActionResult OnGetItem()
    {
        return Partial("Item", new GroceryItem());
    }
}