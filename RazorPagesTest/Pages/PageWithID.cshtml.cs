using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTest.Pages;

public class PageWithIDModel : PageModel
{
	/// <summary>
	/// Wenn per Query-Parameter Daten übergeben werden, kommen diese hier per Parameter an
	/// localhost/PageID?id=10
	/// </summary>
    public void OnGet()
    {

    }

	/// <summary>
	/// Statt void kann hier auch ein IActionResult zurückkommen
	/// </summary>
	public IActionResult OnPost(string vorname)
	{
		if (vorname.Length < 3 || vorname.Length > 15)
			return BadRequest();

		//return Page(); //== return View()
		//Um hier Daten an eine andere Page weitergeben zu können, muss ein anonymes Objekt verwendet werden
		//Jeder Wert in dem anonymen Objekt, muss einen entsprechenden Namen haben, der mit den Parametern der Route der anderen Page übereinstimmt
		return RedirectToPage("Index", new { length = vorname.Length });
	}
}
