using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShowcaseApp.Contollers;
using ShowcaseApp.Data.Model;
using ShowcaseApp.Services;
using System.Data.SqlClient;

namespace ShowcaseApp.Pages.Clients
{
	public class CreateModel : PageModel
	{
		private readonly IClientService _clientService;
		public Client Client = new Client();
		public String ErrorMessage = "";
		public String SuccessMessage = "";

		public CreateModel(IClientService clientService)
		{
			_clientService = clientService;
		}

		public async Task OnPost() 
		{
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
				await _clientService.CreateClientAsync(Client.Name, Client.Phone, Client.Email, Client.Address);
			}
			catch (Exception ex) 
			{
				ErrorMessage = ex.Message;
				return;  
			}

			Client.Name = "";
			Client.Email = "";
			Client.Phone = "";
			Client.Address = "";
			SuccessMessage = "New User Added Correctly";

			Response.Redirect("/Clients/Index");
		}
	}
}
