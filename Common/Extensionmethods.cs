namespace Common
{
	public static class Extensionmethods
	{
		public static bool IsAuthorized(this Userrole role)
		{
			return role == Userrole.Owner || role == Userrole.NormalUser;
		}
	}
}
