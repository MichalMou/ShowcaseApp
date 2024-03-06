using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShowcaseApp.Data.Model;

namespace ShowcaseApp.Contollers
{
	public class ClientController : Controller
	{
		//private readonly ClientRepository _clientRepository;
		public ClientController(IConfiguration configuration)
		{
			//_clientRepository = new ClientRepository("));
		}
		

		public IActionResult MyIndex()
		{
			return Content("Hello world.");
		}
		/*
		public void CreateClient(string name, string phone, string email, string address)
		{
			_clientRepository.CreateClient(name, phone, email, address);
		}

		public void DeleteClient(string id)
		{
			_clientRepository.DeleteClient(id);
		}

		public IEnumerable<Client> GetAllClientsIndex()
		{
			return _clientRepository.GetAllClients();
		}

		public IEnumerable<Client> Index()
		{
			return _clientRepository.GetAllClients();
		}

		public Client GetClient(string id)
		{
			return _clientRepository.GetClient(id);	
		}

		public void UpdateClient(string id, string name, string phone, string email, string address)
		{
			_clientRepository.UpdateClient(id, name, phone, email, address);	
		}*/
	}
}
