using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lokata.Domain.Converters
{
    public class JsonNullableDateOnlyConverter : JsonConverter<DateOnly?>
    {
        private const string DateFormat = "yyyy-MM-dd";

        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var input = reader.GetString();
            if (!string.IsNullOrEmpty(input) && input != "null" && input != "0000-00-00")
                return DateOnly.ParseExact(reader.GetString()!,
                    DateFormat);
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString(
                    DateFormat, CultureInfo.InvariantCulture));
        }
    }
}
