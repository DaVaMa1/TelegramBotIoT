using Telegram.Bot;

namespace BusinessLogicInterfaces
{
	public interface IBotConfiguration
    {
		ITelegramBotClient Client { get; }
	}
}
