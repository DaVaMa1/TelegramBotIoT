using Telegram.Bot;

namespace BusinessLogicInterfaces
{
	public interface IBot
	{
		ITelegramBotClient TelegramBot { get; }
	}
}
