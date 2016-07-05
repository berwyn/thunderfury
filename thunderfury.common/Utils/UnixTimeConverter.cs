using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Thunderfury.Utils
{
	public class UnixTimeConverter : DateTimeConverterBase
	{
		private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null) return null;
			return _epoch.AddMilliseconds((long)reader.Value / 100d);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var date = (DateTime)value;
			writer.WriteRaw((date - _epoch).TotalMilliseconds + "000");
		}
	}
}

