using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NotionSDK.Extensions
{
    public class QueryFilter
    {
        private readonly Dictionary<object, OperandType> _filters = new();

        #region Basic filter condition

        public static object BuildBasic(object filter)
        {
            return new { filter };
        }

        #endregion

        #region Compound filter conditions

        public void Add(object filter, OperandType operandType)
        {
            _filters.Add(filter, operandType);
        }

        // TODO: Add support for nested compounds (i.e. "or" filters inside of "and" filters)
        public object BuildCompound()
        {
            JObject result = new();
            OperandType? currentOperand = null;

            foreach (var filter in _filters)
            {
                if (currentOperand == null || currentOperand == filter.Value)
                {
                    result.Merge((JObject)filter.Key);
                }
                else
                {
                    // TODO: Add way to create nested compounds
                }
                
                currentOperand = filter.Value;
            }

            return JsonConvert.DeserializeObject($"{{ {currentOperand}: [{result}] }}") 
                   ?? throw new JsonException("Failed to build compound filter due to missing/invalid arguments.");
        }

        #endregion

        #region Type-specific filter conditions

        public static object? Checkbox(string property, Comparator comparator, bool value)
        {
            return JsonConvert.DeserializeObject($"{{ \"property\": {property}, \"checkbox\": {{ {comparator.GetDescription()}: {value} }} }}");
        }

        public static object? Date(string property, Comparator comparator, bool value)
        {
            return JsonConvert.DeserializeObject($"{{ \"property\": {property}, \"date\": {{ {comparator.GetDescription()}: {value} }} }}");
        }

        public static object? Date(string property, Comparator comparator, string value)
        {
            return JsonConvert.DeserializeObject($"{{ \"property\": {property}, \"date\": {{ {comparator.GetDescription()}: {value} }} }}");
        }

        public static object? Relation(string property, Comparator comparator, string value)
        {
            return JsonConvert.DeserializeObject($"{{ \"property\": {property}, \"relation\": {{ {comparator.GetDescription()}: {value} }} }}");
        }

        public static object? Relation(string property, Comparator comparator, bool value)
        {
            return JsonConvert.DeserializeObject($"{{ \"property\": {property}, \"relation\": {{ {comparator.GetDescription()}: {value} }} }}");
        }

        #endregion
    }

    public enum OperandType
    {
        [Description("and")]
        And,
        [Description("or")]
        Or
    }

    public enum Comparator
    {
        [Description("equals")]
        Equals,
        [Description("does_not_equal")]
        NotEquals,
        [Description("after")]
        After,
        [Description("before")]
        Before,
        [Description("on_or_after")]
        OnOrAfter,
        [Description("on_or_before")]
        OnOrBefore,
        [Description("contains")]
        Contains,
        [Description("does_not_contain")]
        DoesNotContain,
        [Description("is_empty")]
        IsEmpty,
        [Description("is_not_empty")]
        IsNotEmpty
    }
}
