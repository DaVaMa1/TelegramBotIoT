using Common;
using IDataServices;
using System;

namespace Entities
{
	public class User : IUser
	{
		public Guid Id { get; set; }

		public string Username { get; set; }

		public Userrole Userrole { get; set; }

		public long TelegramUserId { get; set; }

		public bool IsAuthorized()
		{
			return Userrole.IsAuthorized();
		}
	}
}
