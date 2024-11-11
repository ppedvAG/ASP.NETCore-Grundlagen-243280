using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTest.Pages;

public class LoginRegisterModel : PageModel
{
	/// <summary>
	/// WICHTIG: Namensschema beachten
	/// 
	/// OnPost/OnGet/OnDelete, ... + Name der Methode
	/// z.B. OnPostLogin
	/// z.B. OnGetUser
	/// 
	/// Über asp-page="LoginRegister" und asp-page-handler="Login" wird nun dieser Handler verwendet
	/// </summary>
	public void OnPostLogin(string username, string password)
	{

	}

	public void OnPostRegister(string username, string password)
	{

	}
}