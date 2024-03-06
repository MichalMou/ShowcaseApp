using ShowcaseApp.Data.Model;

namespace ShowcaseApp.Services
{
	public interface IClientService
	{
		Task<IEnumerable<Client>> GetAllClientsAsync();
		Task<Client> GetClientsAsync(string? id);
		Task CreateClientAsync(string name, string phone, string email, string address);
		void UpdateClientAsync(string id, string name, string phone, string email, string address);
		Task DeleteClientAsync(string id);

	}
}
