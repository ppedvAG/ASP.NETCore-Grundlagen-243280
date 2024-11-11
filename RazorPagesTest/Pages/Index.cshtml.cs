using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesTest.Pages;

public class IndexModel : PageModel
{
	private readonly ILogger<IndexModel> _logger;

	public int Length;

	public IndexModel(ILogger<IndexModel> logger)
	{
		_logger = logger;
	}

	/// <summary>
	/// Standardmethode, die bei einem GET-Request ausgeführt wird
	/// </summary>
	public void OnGet(int? length)
	{
		Length = length ?? -1;
	}

	/// <summary>
	/// Es können hier auch Methoden definiert werden, welche einen Parameter haben
	/// </summary>
	public void OnGet()
	{

	}
}