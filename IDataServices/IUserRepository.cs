using System.Threading.Tasks;

namespace IDataServices
{
    public interface IUserRepository
    {
		Task<IUser> GetUser(long telegramUserId);

		void CreateUser(long chatId, string username);
	}
}
