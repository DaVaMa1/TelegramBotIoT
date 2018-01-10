using System.Linq;
using System.Data.SqlClient;
using Common;
using Dapper;
using Entities;
using IDataServices;
using System;
using System.Threading.Tasks;

namespace SqlDataServices
{
	public class UserRepository : IUserRepository
	{
		private readonly AppSettings _appSettings;

		public UserRepository(AppSettings appSettings)
		{
			_appSettings = appSettings;
		}

		public void CreateUser(long chatId, string username)
		{
			using (var connection = new SqlConnection(_appSettings.ConnectionString))
			{
				connection.Open();
				connection.Execute($"INSERT INTO [user]([Username], [Userrole], [TelegramUserId]) VALUES ({username}, {Userrole.NormalUser}, {chatId});");
				connection.Close();							  
			}												  
		}

		//This needed to be async for a reason, TODO: look back into why
		public async Task<IUser> GetUser(long telegramUserId)
		{
			//TODO: Make seperate User object for datalayer, better seperation.
			User user = null;
			using (var connection = new SqlConnection(_appSettings.ConnectionString))
			{
				try
				{
					connection.Open();
					user = connection.Query<User>($"SELECT * FROM [user] WHERE TelegramUserId = {telegramUserId};").SingleOrDefault();
					connection.Close();
				}
				//TODO: Specific exception handling, logging
				catch (Exception ex)
				{
					throw;
				}
			}
			return user;
		}
	}
}
