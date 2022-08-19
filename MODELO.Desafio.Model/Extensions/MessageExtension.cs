using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace MODELO.Desafio.Model.Extensions
{
    [ExcludeFromCodeCoverageAttribute]
    public static class MessageExtension
    {
        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var values = Enum.GetValues(type);

            foreach (var val in values)
                if (val.ToString() == value.ToString())
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null) return descriptionAttribute.Description;
                }

            return string.Empty;
        }
    }
}
