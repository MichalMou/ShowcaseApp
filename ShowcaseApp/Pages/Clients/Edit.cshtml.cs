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
		public String SuccessMessage = string.Empty;	

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
			Client.Id = Request.Form["id"];
			Client.Name = Request.Form["name"];
			Client.Email = Request.Form["email"];
			Client.Phone = Request.Form["phone"];
			Client.Address = Request.Form["address"];

			if (Client.Name.Length == 0 || Client.Email.Length == 0 ||
			   Client.Phone.Length == 0 || Client.Address.Length == 0)
			{
				ErrorMessage = "All the fields are required";
				return;
			}

			try
			{
				_clientService.UpdateClientAsync(Client.Id, Client.Name, Client.Email, Client.Phone, Client.Address);
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
