using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using wowapi.Models;
using wowapi.Utils;

namespace wowapi.Services
{
	public enum Region
	{
		US,
		EU,
		KR,
		TW,
		SEA,
		CN,
	}

	public enum Locale
	{
		en_US,
		es_MX,
		pt_BR,
	}

	public class WOWAPIService
	{

		public Locale Locale { get; set; }

		public async Task<Character> GetCharacter(Region region, string realm, string name)
		{
			return await GetCharacter(region, realm, name, new string[] { });
		}

		public async Task<Character> GetCharacter(Region region, string realm, string name, string[] fields)
		{
			var url = generateURL(region);
			var locale = Enum.GetName(typeof(Locale), Locale);
			var fullUrl = $"{url}/character/{realm}/{name}?locale={locale}&apikey={Constants.ApiKey}";

			if (fields.Length > 0)
				fullUrl += $"&fields={ Uri.EscapeDataString(string.Join(",", fields)) }";

			var client = HTTPHelper.Client;
			var req = HTTPHelper.CreateRequest(fullUrl, HttpMethod.Get);
			var res = await client.SendAsync(req);
			var body = await res.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Character>(body);
		}

		private string generateURL(Region region)
		{
			switch (region)
			{
				case Region.US:
				case Region.EU:
				case Region.KR:
				case Region.TW:
				case Region.SEA:
					return $"https://{ Enum.GetName(typeof(Region), region) }.api.battle.net/wow";
				case Region.CN:
					return "https://www.battlenet.com.cn/api/wow";
				default:
					return "https://us.api.battle.net/wow";
			}
	}
}

