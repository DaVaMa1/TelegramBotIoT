using Common;
using System;

namespace IDataServices
{
	public interface IUser
	{
		Guid Id { get; set; }

		string Username { get; set; }

		Userrole Userrole { get; set; }

		long TelegramUserId { get; set; }

		bool IsAuthorized();
	}
}
