using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Thunderfury.Tests.Mocks
{
	public class MockHttpClient : DelegatingHandler
	{
		private readonly Dictionary<Uri, HttpResponseMessage> _fakes = new Dictionary<Uri, HttpResponseMessage>();

		public void AddFake(Uri uri, HttpResponseMessage message)
		{
			this._fakes.Add(uri, message);
		}

		protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken token)
		{
			return await Task.Run(() =>
			{
				if (_fakes.ContainsKey(request.RequestUri))
				{
					return _fakes[request.RequestUri];
				}
				return new HttpResponseMessage(HttpStatusCode.NotFound) { RequestMessage = request };
			});
		}
	}
}

