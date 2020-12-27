using System;
using System.Globalization;

namespace Infra.Data.Helpers
{
    public static class DataHelpers
    {
        public static T CheckUpdateObject<T>(T originalObj, T updateObj) where T : class
        {
            foreach (var property in updateObj.GetType().GetProperties())
            {
                var updateValue = property.GetValue(updateObj, null);
                var originalValue = originalObj.GetType().GetProperty(property.Name)?.GetValue(originalObj, null);

                if (updateValue == null || updateValue?.ToString() == DateTime.MinValue.ToString(CultureInfo.CurrentCulture))
                {
                    property.SetValue(updateObj, originalValue);
                }
            }
            return updateObj;
        }
    }
}
