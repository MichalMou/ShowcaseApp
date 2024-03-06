using ShowcaseApp.Data.Model;

namespace ShowcaseApp.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _clientRepository;

		public ClientService(IClientRepository clientRepository)
		{
			_clientRepository = clientRepository;
		}

		public async Task CreateClientAsync(string name, string phone, string email, string address)
		{
			await _clientRepository.CreateClientAsync(name, phone, email, address);
		}

		public async Task DeleteClientAsync(string id)
		{
			await _clientRepository.DeleteClientAsync(id);
		}

		public async Task<IEnumerable<Client>> GetAllClientsAsync()
		{
			return await _clientRepository.GetAllClientsAsync();
		}

		public async Task<Client> GetClientsAsync(string? id)
		{
			return await _clientRepository.GetClientAsync(id);
		}

		public void UpdateClientAsync(string id, string name, string phone, string email, string address)
		{
			_clientRepository.UpdateClientAsync(id, name, phone, email, address);
		}
	}
}
