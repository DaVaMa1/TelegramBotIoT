using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiDataServices
{
	public static class ApiConnector
	{
		public static HttpClient _client = SetupClient();

		private static HttpClient SetupClient()
		{
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://192.168.0.109:61996/api/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
			return client;
		}
	}
}
