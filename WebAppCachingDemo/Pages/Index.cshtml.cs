using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCachingDemo.Models;
using WebAppCachingDemo.Utilities;

namespace WebAppCachingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICachedData _cachedData;

        public List<Widget> Widgets { get; set; } = new List<Widget>();

        public IndexModel(ILogger<IndexModel> logger, ICachedData cachedData)
        {
            _logger = logger;
            _cachedData = cachedData;
        }

        public void OnGet()
        {
            Widgets = _cachedData.GetWidgets();
        }
    }
}
