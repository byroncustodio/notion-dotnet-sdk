using System.ComponentModel;

namespace NotionSDK.Extensions
{
    public class QueryFilter
    {
        private string _compoundFilter = string.Empty;
        private readonly Dictionary<string, OperandType> _filters = new();

        #region Basic filter condition

        public static string BuildBasic(string filter)
        {
            return string.Format(GetBasicFormat(), filter);
        }

        #endregion

        #region Compound filter conditions

        public void StartCompound()
        {
            _compoundFilter = GetCompoundFormat();
        }

        public void Add(string filter, OperandType operandType)
        {
            _filters.Add(filter, operandType);
        }

        // TODO: Add support for nested compounds (i.e. "or" filters inside of "and" filters)
        public string BuildCompound()
        {
            var filterResult = string.Empty;
            OperandType? currentOperand = null;

            foreach (var filter in _filters)
            {
                if (currentOperand == null)
                {
                    filterResult = filter.Key;
                    currentOperand = filter.Value;
                }
                //else if (currentOperand != filter.Value)
                //{
                //    filterResult = string.Join(",", filterResult, string.Format(GetCompoundFormat(), filter.Value));
                //    currentOperand = filter.Value;
                //}
                else
                {
                    filterResult = string.Join(",", filterResult, filter.Key);
                    currentOperand = filter.Value;
                }
            }

            return string.Format(_compoundFilter, currentOperand, filterResult);
        }

        #endregion

        #region Type-specific filter conditions

        public static string Checkbox(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "checkbox", property, comparator.GetDescription(), value);
        }

        public static string Date(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "date", property, comparator.GetDescription(), value);
        }

        public static string Date(string property, Comparator comparator, string value)
        {
            return string.Format(GetConditionFormat(), "date", property, comparator.GetDescription(), value);
        }

        public static string Relation(string property, Comparator comparator, string value)
        {
            return string.Format(GetConditionFormat(), "relation", property, comparator.GetDescription(), value);
        }

        public static string Relation(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "relation", property, comparator.GetDescription(), value);
        }

        #endregion

        #region Json formats

        private static string GetBasicFormat()
        {
            return "{ 'filter': {0} }";
        }

        private static string GetCompoundFormat()
        {
            return "{ '{0}': [{1}] }";
        }

        private static string GetConditionFormat()
        {
            return @"{ 'property': {1},
                       '{0}': {
                            '{2}': {3}
                        }
                      }";
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
