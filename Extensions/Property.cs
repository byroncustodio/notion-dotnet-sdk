using NotionSDK.Models.Property;

namespace NotionSDK.Extensions
{
    public class Property
    {


        public Property() { }

        public string Title(Title title)
        {
            var item = title.Items.FirstOrDefault();
            //return string.Format(GetFormat(), );
            return string.Empty;
        }

        private string GetFormat()
        {
            return
            @"{
                '{0}': {
                    '{1}': {
                        '{2}': {3}
                    }
                }
              }";
        }

        // TODO: properties json gets set on database update method
    }
}
