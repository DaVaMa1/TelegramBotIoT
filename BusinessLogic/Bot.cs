using Telegram.Bot;
using Telegram.Bot.Args;
using BusinessLogicInterfaces;
using IDataServices;

namespace BusinessLogic
{
	public class Bot : IBot
	{
		private IBotConfiguration _configuration;
		private IUserRepository _userRepository;

		public Bot(IBotConfiguration configuration, IUserRepository userRepository)
		{
			_configuration = configuration;
			_userRepository = userRepository;
			ConfigureBot();
		}

		public ITelegramBotClient TelegramBot => _configuration.Client;

		private void ConfigureBot()
		{
			_configuration.Client.GetMeAsync().Wait();
			_configuration.Client.GetUpdatesAsync().GetAwaiter();
			_configuration.Client.OnMessage += ProcessMessageReceived;
			_configuration.Client.StartReceiving();
		}

		private void ProcessMessageReceived(object sender, MessageEventArgs e)
		{
			string message = "";
			switch (e.Message.Text)
			{
				case "/createuser":
					message = CreateUser(e.Message.Chat.Id, e.Message.Contact.FirstName + e.Message.Contact.LastName);
					break;
				case "/sayhello":
					message = SayHello(e.Message.Chat.Id);
					break;
			}
			_configuration.Client.SendTextMessageAsync(e.Message.Chat.Id, message);
		}

		private string SayHello(long id)
		{
			var user = _userRepository.GetUser(id).Result;
			if (user != null)
			{
				return "Hellllooooooo!";
			}
			return "User is not known.....";
		}

		private string CreateUser(long id, string username)
		{
			if (_userRepository.GetUser(id) != null)
			{
				_userRepository.CreateUser(id, username);
				return "User succesfully created! :)";
			}
			return "User already exists! >:)";
		}

		private bool ConfirmUserIsAuthorized(int telegramUserId)
		{
			return _userRepository.GetUser(telegramUserId)?.Result.IsAuthorized() == true;
		}
	}
}
