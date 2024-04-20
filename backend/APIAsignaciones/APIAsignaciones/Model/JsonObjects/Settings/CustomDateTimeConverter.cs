using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace APIAsignaciones.Model.JsonObjects.Settings
{
    /// <summary>
    /// Personaliza el formato de las fechas al usar JsonConvert
    /// </summary>
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy H:mm"));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string dateValue = reader.Value.ToString();
                if (DateTime.TryParseExact(dateValue, "dd/MM/yyyy H:mm", null, System.Globalization.DateTimeStyles.None, out DateTime parsedDate))
                {
                    return parsedDate;
                }
            }
            throw new JsonSerializationException("Invalid date format.");
        }
    }
}
