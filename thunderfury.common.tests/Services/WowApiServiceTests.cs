using System;
using NUnit.Framework;
using Thunderfury.Utils;
using Thunderfury.Tests.Mocks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Thunderfury.Models;
using Thunderfury.Services;
using System.Threading.Tasks;

namespace Thunderfury.Tests.Services
{
	[TestFixture]
	public class WowApiServiceTests
	{
		private MockHttpClient _delegate;
		private WowApiService _service;

		[SetUp]
		public void Setup()
		{
			_delegate = new MockHttpClient();
			_service = new WowApiService();
			HTTPHelper.Handler = _delegate;
		}

		[Test]
		public async Task TestCharacterApi()
		{
			var fakeCharacter = new Character()
			{
				Name = "Bergit",
				Realm = "Duskwood",
				Battlegroup = "Ruin",
				Level = 100,
				Class = Class.Warrior,
				Faction = Faction.Alliance,
				Race = Race.Worgen,
				Gender = Gender.Female,
				LastModified = DateTime.UtcNow,
				CalcClass = "Z",
				HonorableKills = 272,
				Thumbnail = "bloodhoof/187/173993403-avatar.jpg",
				AchievementPoints = 6850,
			};

			var mockResponse = new HttpResponseMessage(HttpStatusCode.OK)
			{
				Content = new StringContent(JsonConvert.SerializeObject(fakeCharacter)),
			};

			_delegate.AddFake(
				new Uri($"https://us.api.battle.net/character/Duskwood/Bergit?locale=en_us&apikey={Constants.ApiKey}"),
				mockResponse
			);

			var toon = await _service.GetCharacter(Region.US, "Duskwood", "Bergit");
			Assert.AreEqual(fakeCharacter, toon, "Characters should be equivalent");
		}
	}
}

