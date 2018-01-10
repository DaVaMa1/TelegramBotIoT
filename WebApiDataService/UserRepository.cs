using System.Linq;
using Common;
using Entities;
using IDataServices;
using System;

namespace WebApiDataService
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

		public IUser GetUser(long telegramUserId)
		{
			User user;
			using (var connection = new SqlConnection(_appSettings.ConnectionString))
			{
				try
				{
					connection.Open();
					user = connection.Query<User>($"SELECT * FROM [user] WHERE TelegramUserId = {telegramUserId};").SingleOrDefault();
					connection.Close();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
			return user;
		}
	}
}
