using System;
using System.Threading.Tasks;
using BusinessLogic;
using Common;
using WebApiDataServices;
using Windows.ApplicationModel.Background;

namespace TelegramBotIoT
{
	public sealed class StartupTask : IBackgroundTask
	{
		BackgroundTaskDeferral deferral;
		public void Run(IBackgroundTaskInstance taskInstance)
		{
			//Needed for running continuous background tasks in Windows IoT
			deferral = taskInstance.GetDeferral();
			RunBot();
		}

		private static void RunBot()
		{
			Bot bot = null;
			
			try
			{
				//TODO: Maybe use Di framework, Ninject?
				bot = new Bot(
					new BotConfiguration(
						new AppSettings()),
					new UserRepository(
						new AppSettings()));

				while (true)
				{
					var t = Task.Run(async delegate
					{
						await Task.Delay(1000);
					});
					t.Wait();
				}
			}
			catch (Exception)
			{
				//TODO: Add Logging
				if (bot != null)
				{
					SafeClose(bot);
				}
			}
		}

		//TODO: Figure out how to actually safely close, do I even need to?
		private static void SafeClose(Bot bot)
		{
			bot.TelegramBot.StopReceiving();
		}
	}
}
