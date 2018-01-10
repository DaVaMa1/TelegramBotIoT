using System;
using System.Threading;
using BusinessLogic;
using Common;
using DataServices;

namespace TelegramBotConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			RunBot();
		}

		private static void RunBot()
		{
			Bot bot = null;
			try
			{
				bot = new Bot(
					new BotConfiguration(
						new AppSettings()),
					new UserRepository(
						new AppSettings()));

				while (true)
				{
					Thread.Sleep(250);
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

		private static void SafeClose(Bot bot)
		{
			bot.TelegramBot.StopReceiving();
			Environment.Exit(-1);
		}
	}
}