namespace Common
{
	public class AppSettings
	{
		public string ConnectionString => "Server=localhost;Database=TelegramBot;Trusted_Connection=True;";

		//Change to xml configuration(I think?) for easier uploading to public repositories.(Exclude file in upload)
		public string Token=> "";

		public AppSettings()
		{
		}
	}
}
