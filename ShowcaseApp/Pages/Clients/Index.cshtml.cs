using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShowcaseApp.Contollers;
using ShowcaseApp.Data.Model;
using ShowcaseApp.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace ShowcaseApp.Pages.Clients
{
	public class IndexModel : PageModel
	{
		private readonly IClientService _clientService;
		public IEnumerable<Client> ListClients { get; set; }

		public IndexModel(IClientService clientService)
		{
			_clientService = clientService;
		}

		public async Task OnGetAsync()
		{
			ListClients = await _clientService.GetAllClientsAsync();
		}
	}
}
