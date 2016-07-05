using System;
namespace Thunderfury.Models
{
	public enum Class
	{
		Warrior = 1,
		Paladin = 2,
		Hunter = 3,
		Rogue = 4,
		Priest = 5,
		DeathKnight = 6,
		Shaman = 7,
		Mage = 8,
		Warlock = 9,
		Monk = 10,
		Druid = 11,
	}

	public enum PowerType
	{
		Focus,
		Rage,
		RunicPower,
		Energy,
		Mana,
	}

	public enum Race
	{
		Human = 1,
		Orc = 2,
		Dwarf = 3,
		NightElf = 4,
		Undead = 5,
		Tauren = 6,
		Gnome = 7,
		Troll = 8,
		Goblin = 9,
		BloodElf = 10,
		Draenai = 11,
		Worgen = 22,
		NeutralPandaren = 24,
		AlliancePandaren = 25,
		HordePandaren = 26,
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
		Neutral = 3,
	}

	public static partial class ModelHelper
	{
		/// <summary>
		/// Calculates the mask for a given class
		/// </summary>
		/// <param name="cls">The character's class</param>
		/// <remarks>No idea what this is for :/</remarks>
		public static int Mask(this Class cls)
		{
			return Convert.ToInt32(Math.Pow(2, (int)cls - 1));
		}

		/// <summary>
		/// Returns the power type used by a class
		/// </summary>
		/// <returns>The character's power type</returns>
		/// <param name="cls">The character's class</param>
		public static PowerType PowerType(this Class cls)
		{
			switch (cls)
			{
				case Class.Hunter:
					return Models.PowerType.Focus;
				case Class.Warrior:
					return Models.PowerType.Rage;
				case Class.DeathKnight:
					return Models.PowerType.RunicPower;
				case Class.Rogue:
				case Class.Monk:
					return Models.PowerType.Energy;
				default:
					return Models.PowerType.Mana;
			}
		}

		/// <summary>
		/// Returns the raid color for an associated class
		/// </summary>
		/// <param name="cls">The character's class</param>
		/// <returns>An (R, G, B) tuple</returns>
		public static Tuple<int, int, int> Color(this Class cls)
		{
			switch (cls)
			{
				default:
				case Class.Warrior:
					return Tuple.Create(199, 156, 110);
				case Class.Paladin:
					return Tuple.Create(245, 140, 186);
				case Class.Hunter:
					return Tuple.Create(171, 212, 115);
				case Class.Rogue:
					return Tuple.Create(255, 245, 105);
				case Class.Priest:
					return Tuple.Create(255, 255, 255);
				case Class.DeathKnight:
					return Tuple.Create(196, 30, 59);
				case Class.Shaman:
					return Tuple.Create(0, 122, 222);
				case Class.Mage:
					return Tuple.Create(105, 204, 240);
				case Class.Warlock:
					return Tuple.Create(148, 130, 201);
				case Class.Monk:
					return Tuple.Create(0, 255, 150);
				case Class.Druid:
					return Tuple.Create(255, 125, 10);
			}
		}

		/// <summary>
		/// Calculates the mask for a given race
		/// </summary>
		/// <param name="race">The character's race</param>
		/// <remarks>No idea what this is for :/</remarks>
		public static int Mask(this Race race)
		{
			return Convert.ToInt32(Math.Pow(2, (int)race - 1));
		}

		/// <summary>
		/// Returns the faction a race belongs to
		/// </summary>
		/// <param name="race">The character's race</param>
		public static Faction Faction(this Race race)
		{
			switch (race)
			{
				case Race.Human:
				case Race.Dwarf:
				case Race.NightElf:
				case Race.Gnome:
				case Race.Draenai:
				case Race.Worgen:
				case Race.AlliancePandaren:
					return Models.Faction.Alliance;
				case Race.Orc:
				case Race.Undead:
				case Race.Tauren:
				case Race.Troll:
				case Race.Goblin:
				case Race.BloodElf:
				case Race.HordePandaren:
					return Models.Faction.Horde;
				default:
					return Models.Faction.Neutral;
			}
		}
	}
}

