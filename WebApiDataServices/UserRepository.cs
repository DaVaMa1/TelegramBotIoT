using Common;
using Entities;
using IDataServices;
using System;
using System.Threading.Tasks;
using System.Net.Http;

namespace WebApiDataServices
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
			throw new NotImplementedException();
		}

		public async Task<IUser> GetUser(long telegramUserId)
		{
			try
			{
				User user = null;
				var response = await ApiConnector._client.GetAsync($"user/{telegramUserId}");
				if (response.IsSuccessStatusCode)
				{
					user = await response.Content.ReadAsAsync<User>();
				}
				return user;
			}
			//TODO: Specific exception handling, now for debugging
			catch (Exception e)
			{
				throw;
			}
		}
	}
}
