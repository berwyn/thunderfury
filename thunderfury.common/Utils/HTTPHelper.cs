using System;
using System.Net.Http;

namespace wowapi.Utils
{
	public sealed class HTTPHelper
	{

		private static HttpClient _client;
		public static HttpClient Client
		{
			get
			{
				if(_client == null)
					_client = new HttpClient();
				return _client;
			}
		}

		public static HttpRequestMessage CreateRequest(string url, HttpMethod method)
		{
			var req = new HttpRequestMessage(method, url);
			req.Headers.Add("User-Agent", "thunderfury/1.0.0-alpha.1");
			req.Headers.Add("Accept", "application/json");
			return req;
		}
	}
}

