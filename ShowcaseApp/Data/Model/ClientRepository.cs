using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ShowcaseApp.Data.Model
{
	public class ClientRepository : IClientRepository
	{
		private List<Client> _clients;
		private readonly string _connectionString;

		public ClientRepository(IConfiguration configuration) 
		{
			_clients = new List<Client>();
			_connectionString = configuration.GetConnectionString("ClientsConnectionString");
			if (string.IsNullOrEmpty(_connectionString));
		}

		public async Task CreateClientAsync(string name, string phone, string email, string address)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				string sql = "INSERT INTO users " +
					"(name, email, phone, address) VALUES " +
					"(@name, @email, @phone, @address);";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@name", name);
					command.Parameters.AddWithValue("@email", email);
					command.Parameters.AddWithValue("@phone", phone);
					command.Parameters.AddWithValue("@address", address);

					await command.ExecuteNonQueryAsync();
				}
			}
		}

		public async Task DeleteClientAsync(string id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();

				string sql = "DELETE FROM users WHERE id=@id;";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@id", id);

					command.ExecuteNonQuery();
				}
			}
		}

		public async Task<IEnumerable<Client>> GetAllClientsAsync()
		{
			List<Client> listClients = new List<Client>();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				string sql = "SELECT id, name, email, phone, address, reg_dat FROM users";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Client client = new Client();
							client.Id = "" + reader.GetInt32(0);
							client.Name = reader.GetString(1);
							client.Email = reader.GetString(2);
							client.Phone = reader.GetString(3);
							client.Address = reader.GetString(4);
							client.RegDate = reader.GetDateTime(5).ToString();

							listClients.Add(client);
						}
					}
				}
			}
			return listClients;
		}

		public async Task<Client> GetClientAsync(string id)
		{
			Client client = new Client();
			if (id == null)
			{
				return client;
			}

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				await connection.OpenAsync();
				string sql = "SELECT id, name, email, phone, address FROM users WHERE id=@id";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.AddWithValue("@id", id);
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							client.Id = "" + reader.GetInt32(0);
							client.Name = reader.GetString(1);
							client.Email = reader.GetString(2);
							client.Phone = reader.GetString(3);
							client.Address = reader.GetString(4);
						}
					}
				}
			}
			return client;
		}

		public void UpdateClientAsync(string id, string name, string phone, string email, string address)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					string sql = "UPDATE users SET name = @name, email = @email, phone = @phone, address = @address WHERE id = @id;";
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.Parameters.AddWithValue("@name", name);
						command.Parameters.AddWithValue("@email", email);
						command.Parameters.AddWithValue("@phone", phone);
						command.Parameters.AddWithValue("@address", address);
						command.Parameters.AddWithValue("@id", id);

						command.ExecuteNonQuery();
					}
				}
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
				throw; // Or handle it appropriately
			}
		}
	}
}
