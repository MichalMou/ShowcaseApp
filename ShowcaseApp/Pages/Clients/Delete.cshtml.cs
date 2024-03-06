using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShowcaseApp.Data.Model;
using ShowcaseApp.Services;

namespace ShowcaseApp.Pages.Clients
{
    public class DeleteModel : PageModel
    {
		private readonly IClientService _clientService;

		public DeleteModel(IClientService clientService)
		{
			_clientService = clientService;
		}
		public async Task OnGetAsync()
		{
			String id = Request.Query["id"];

			await _clientService.DeleteClientAsync(id);

			Response.Redirect("/Clients/Index");
		}
	}
}
