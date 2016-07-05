using System;
using Newtonsoft.Json;
using Thunderfury.Utils;

namespace Thunderfury.Models
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Character
	{
		[JsonProperty("lastModified")]
		[JsonConverter(typeof(UnixTimeConverter))]
		public DateTime LastModified { get; }
		[JsonProperty("name")]
		public string Name { get; }
		[JsonProperty("realm")]
		public string Realm { get; }
		[JsonProperty("battlegroup")]
		public string Battlegroup { get; }
		[JsonProperty("class")]
		public Class Class { get; }
		[JsonProperty("race")]
		public Race Race { get; }
		[JsonProperty("gender")]
		public Gender Gender { get; }
		[JsonProperty("level")]
		public byte Level { get; }
		[JsonProperty("achievementPoints")]
		public int AchievementPoints { get; }
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; }
		[JsonProperty("calcClass")]
		public string CalcClass { get; }
		[JsonProperty("faction")]
		public Faction Faction { get; }
		[JsonProperty("totalHonorableKills")]
		public int HonorableKills { get; }
		[JsonProperty("guildName")]
		public string GuildName { get; }
		[JsonProperty("guildRealm")]
		public string GuildRealm { get; }

		#region Optional Fields

		[JsonProperty("guild")]
		public Guild Guild { get; }

		#endregion

	}

	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Guild
	{
		[JsonProperty("lastModified")]
		[JsonConverter(typeof(UnixTimeConverter))]
		public DateTime LastModified { get; }
		[JsonProperty("name")]
		public string Name { get; }
		[JsonProperty("realm")]
		public string Realm { get; }
		[JsonProperty("battlegroup")]
		public string Battlegroup { get; }
		[JsonProperty("level")]
		public byte Level { get; }
		[JsonProperty("side")]
		public Faction Side { get; }
		[JsonProperty("achievementPoints")]
		public int AchievementPoints { get; }
		public GuildEmblem Emblem { get; }

		#region Optional Fields

		[JsonProperty("members")]
		public GuildCharacter[] Characters { get; }

		[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
		public class GuildEmblem
		{
			[JsonProperty("icon")]
			public byte Icon { get; }
			[JsonProperty("iconColor")]
			public string IconColor { get; }
			[JsonProperty("border")]
			public byte Border { get; }
			[JsonProperty("borderColor")]
			public string BorderColor { get; }
			[JsonProperty("backgroundColor")]
			public string BackgroundColor { get; }
		}

		[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
		public class GuildCharacter
		{
			[JsonProperty("character")]
			public Character Character { get; }
			[JsonProperty("rank")]
			public byte Rank { get; }
		}
	}
}

