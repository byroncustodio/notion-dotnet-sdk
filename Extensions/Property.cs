using Newtonsoft.Json;
using NotionSDK.Models.Property;

namespace NotionSDK.Extensions
{
    public class Property
    {
        private string _properties = string.Empty;

        public Property() { }

        public void Add(string name, string property)
        {
            _properties = string.Join(",", _properties, string.Format(GetBaseFormat(), name, property));
        }

        public string Build()
        {
            return string.Format("{{ properties: {{ {0} }} }}", _properties);
        }
        
        public string Title(Title title)
        {
            return JsonConvert.SerializeObject(title);
        }

        public string Date(Date date)
        {
            return string.Format(GetBaseFormat(), "date", JsonConvert.SerializeObject(date));
        }

        public string Relation(Relation relation)
        {
            return JsonConvert.SerializeObject(relation);
        }

        public string Select(Select select)
        {
            return string.Format(GetBaseFormat(), "select", JsonConvert.SerializeObject(select));
        }

        public string Number(Number number)
        {
            return string.Format(GetBaseFormat(), "number", JsonConvert.SerializeObject(number));
        }

        public string Status(Status status)
        {
            return string.Format(GetBaseFormat(), "status", JsonConvert.SerializeObject(status));
        }

        public string RichText(RichText richText)
        {
            return JsonConvert.SerializeObject(richText);
        }

        private string GetBaseFormat()
        {
            return
            @"{
                '{0}': '{1}'
              }";
        }
    }
}
