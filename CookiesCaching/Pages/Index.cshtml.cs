using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CookiesCaching.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		public string Datum;

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			//Cookie prüfen
			if (HttpContext.Request.Cookies["TestCookie"] != null) //Prüfen, ob der TestCookie gesetzt ist
			{
				Datum = HttpContext.Request.Cookies["TestCookie"];
			}
			else
			{
				//Cookie setzen
				CookieOptions co = new CookieOptions();
				co.Expires = DateTimeOffset.Now + TimeSpan.FromMinutes(1);

				HttpContext.Response.Cookies.Append("TestCookie", "Das ist ein Test", co);
			}
		}
	}
}
