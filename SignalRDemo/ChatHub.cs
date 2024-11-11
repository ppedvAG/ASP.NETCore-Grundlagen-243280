using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo;

/// <summary>
/// In Program.cs:
/// - builder.Services.AddSignalR();
/// - app.MapHub<ChatHub>("/chat");
/// </summary>
public class ChatHub : Hub
{
	/// <summary>
	/// Diese Methode wird von JS aufgerufen, und soll an alle anderen Clients die Nachricht übermitteln
	/// </summary>
	/// <returns></returns>
	public async Task NachrichtSenden(string user, string nachricht)
	{
		//Hier wird bei conn.on die entsprechende Nachricht ausgeführt
		await Clients.All.SendAsync("NachrichtEmpfangen", user, nachricht);
	}
}
