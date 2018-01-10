using Common;
using Telegram.Bot;
using BusinessLogicInterfaces;

namespace BusinessLogic
{
	public class BotConfiguration : IBotConfiguration
	{
		private AppSettings _settings;
		private ITelegramBotClient _client;

		public ITelegramBotClient Client => _client;
		public BotConfiguration(AppSettings setting)
		{
			_settings = setting;
			_client = new TelegramBotClient(_settings.Token);
		}
	}
}
