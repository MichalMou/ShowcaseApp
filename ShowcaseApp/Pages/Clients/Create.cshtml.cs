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
		public Client client = new Client();
		public String errorMessage = "";
		public String successMessage = "";

		public CreateModel(IClientService clientService)
		{
			_clientService = clientService;
		}

		public async Task OnPost() 
		{
            client.name = Request.Form["name"];
            client.email = Request.Form["email"];
			client.phone = Request.Form["phone"];
			client.address = Request.Form["address"];

			if (client.name.Length == 0 || client.email.Length == 0 ||
                client.phone.Length == 0 || client.address.Length == 0) 
			{
				errorMessage = "All the fields are required";
				return;
			}

			try
			{
				await _clientService.CreateClientAsync(client.name, client.phone, client.email, client.address);
			}
			catch (Exception ex) 
			{
				errorMessage = ex.Message;
				return;  
			}

            client.name = "";
            client.email = "";
            client.phone = "";
            client.address = "";
			successMessage = "New User Added Correctly";

			Response.Redirect("/Clients/Index");
		}
	}
}
