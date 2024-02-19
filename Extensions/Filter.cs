using System.ComponentModel;

namespace NotionSDK.Extensions
{
    public class Filter
    {
        private string _compoundFilter = string.Empty;
        private Dictionary<string, OperandType> _filters = new();

        public Filter() { }

        #region Basic filter condition

        public string BuildBasic(string filter)
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

        public string Checkbox(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "checkbox", property, Common.GetDescription(comparator), value);
        }

        public string Date(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "date", property, Common.GetDescription(comparator), value);
        }

        public string Date(string property, Comparator comparator, string value)
        {
            return string.Format(GetConditionFormat(), "date", property, Common.GetDescription(comparator), value);
        }

        public string Relation(string property, Comparator comparator, string value)
        {
            return string.Format(GetConditionFormat(), "relation", property, Common.GetDescription(comparator), value);
        }

        public string Relation(string property, Comparator comparator, bool value)
        {
            return string.Format(GetConditionFormat(), "relation", property, Common.GetDescription(comparator), value);
        }

        #endregion

        #region Json formats

        private string GetBasicFormat()
        {
            return 
            @"{
                'filter': {0}
              }";
        }

        private string GetCompoundFormat()
        {
            return
            @"{
                '{0}': [{1}]
              }";
        }

        private string GetConditionFormat()
        {
            return
            @"{
                'property': {1},
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
