using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShowcaseApp.Contollers;
using ShowcaseApp.Data.Model;
using ShowcaseApp.Services;
using System.Data.SqlClient;

namespace ShowcaseApp.Pages.Clients
{
    public class EditModel : PageModel
	{
		private readonly IClientService _clientService;
		public Client Client = new Client();
		public string ClientId { get; set; }
		public string ErrorMessage = string.Empty;
		public String successMessage = string.Empty;	

		public EditModel(IClientService clientService)
		{
			_clientService = clientService;
		}

		public async Task OnGetAsync()
		{
			ClientId = Request.Query["id"];

			try
			{
				Client = await _clientService.GetClientsAsync(ClientId);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return;
			}
		}

		public void OnPost()
		{
			Client.id = Request.Form["id"];
			Client.name = Request.Form["name"];
			Client.email = Request.Form["email"];
			Client.phone = Request.Form["phone"];
			Client.address = Request.Form["address"];

			if (Client.name.Length == 0 || Client.email.Length == 0 ||
			   Client.phone.Length == 0 || Client.address.Length == 0)
			{
				ErrorMessage = "All the fields are required";
				return;
			}

			try
			{
				_clientService.UpdateClientAsync(Client.id, Client.name, Client.email, Client.phone, Client.address);
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
				return;
			}

			Response.Redirect("/Clients/Index");
		}    
	}
}
