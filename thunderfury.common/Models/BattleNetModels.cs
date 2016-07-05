using System;
using Newtonsoft.Json;

namespace wowapi.Models
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class Character
	{

		public DateTime LastModified { get; }
		public string Name { get; }
		public string Realm { get; }
		public string Battlegroup { get; }
		public Class Class { get; }
		public Race Race { get; }
		public Gender Gender { get; }
		public byte Level { get; }
		public int AchievementPoints { get; }
		public string Thumbnail { get; }
		public string CalcClass { get; }
		public Faction Faction { get; }
		public int HonorableKills { get; }

	}

	public enum Class
	{
	}

	public enum Race
	{
	}

	public enum Gender
	{
		Male = 0,
		Female = 1,
	}

	public enum Faction
	{
		Alliance = 0,
		Horde = 1,
	}
}

