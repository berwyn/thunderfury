using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Thunderfury.Models;
using Thunderfury.Utils;

namespace Thunderfury.Services
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

		/// <summary>
		/// The locale for API results to provide localised results
		/// for.
		/// </summary>
		/// <value>The user's locale</value>
		public Locale Locale { get; set; }

		/// <summary>
		/// Gets a character with only the default fields.
		/// </summary>
		/// <returns>The character.</returns>
		/// <param name="region">The region the character is on.</param>
		/// <param name="realm">The realm the character is on.</param>
		/// <param name="name">The character's name.</param>
		public async Task<Character> GetCharacter(Region region, string realm, string name)
		{
			return await GetCharacter(region, realm, name, new string[] { });
		}

		/// <summary>
		/// Gets a character with a series of optional fields.
		/// </summary>
		/// <returns>The character.</returns>
		/// <param name="region">The region the character is on.</param>
		/// <param name="realm">The realm the character is on.</param>
		/// <param name="name">The character's name.</param>
		/// <param name="fields">Optional fields to retrieve</param>
		public async Task<Character> GetCharacter(Region region, string realm, string name, string[] fields)
		{
			var query = fields.Length == 0
				? new string[][] { }
				: new[] { new[] { "fields" }.Concat(fields).ToArray() };
			var url = generateUrl(region, new[] { "character", realm, name }, query);

			var client = HTTPHelper.Client;
			var req = HTTPHelper.CreateRequest(url, HttpMethod.Get);
			var res = await client.SendAsync(req);
			var body = await res.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Character>(body);
		}

		/// <summary>
		/// Gets a guild with only the default fields.
		/// </summary>
		/// <returns>The guild.</returns>
		/// <param name="region">The region the guild is on.</param>
		/// <param name="realm">The realm the guild is on.</param>
		/// <param name="name">The name of the guild.</param>
		public async Task<Guild> GetGuild(Region region, string realm, string name)
		{
			return await GetGuild(region, realm, name, new string[] { });
		}

		/// <summary>
		/// Gets a guild with optional fields
		/// </summary>
		/// <returns>The guild.</returns>
		/// <param name="region">The region the guild is on.</param>
		/// <param name="realm">The realm the guild is on.</param>
		/// <param name="name">The name of the guild.</param>
		/// <param name="fields">Optional fields to retrieve</param>
		public async Task<Guild> GetGuild(Region region, string realm, string name, string[] fields)
		{
			string[][] query = fields.Length == 0
                ? new string[][] { }
				: new[] { new[] { "fields" }.Concat(fields).ToArray() };
			var url = generateUrl(region, new[] { "guild", realm, name }, query);

			var client = HTTPHelper.Client;
			var req = HTTPHelper.CreateRequest(url, HttpMethod.Get);
			var res = await client.SendAsync(req);
			var body = await res.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<Guild>(body);
		}

		private string generateUrl(Region region, string[] parts, string[][] queryParams)
		{
			var root = generateBaseURL(region);
			var locale = Enum.GetName(typeof(Locale), Locale);
			var stem = String.Join("/", parts.Select(p => Uri.EscapeUriString(p)));

			var query = queryParams.Select(param =>
			{
				if (param.Length == 2)
				{
					return $"{param[0]}={param[1]}";
				}
				return $"{param[0]}={ String.Join(",", param.Skip(1).Take(param.Length - 1)) }";
			}).ToArray();

			var url = $"{root}/{stem}?locale={locale}&apikey={Constants.ApiKey}";

			if (query.Length > 0) url += $"&{String.Join("&", query)}";

			return url;
		}

		private string generateBaseURL(Region region)
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
}

