namespace ShowcaseApp.Data.Model
{
	public interface IClientRepository
	{
		Task CreateClientAsync(string name, string phone, string email, string address);
		Task DeleteClientAsync(string id);
		Task<IEnumerable<Client>> GetAllClientsAsync();
		Task<Client> GetClientAsync(string id);
		void UpdateClientAsync(string id, string name, string phone, string email, string address);
	}
}
