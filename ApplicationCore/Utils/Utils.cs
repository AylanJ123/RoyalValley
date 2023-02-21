using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Utils
{
    namespace Enums
    {
        public enum EstadoConstruccion : byte
        {
            [Description("Lote Baldío")]
            Lote = 0,
            [Description("En Construcción")]
            Obra = 1,
            [Description("Construido")]
            Construido = 2,
        }
    }

    namespace Extensions
    {
        public static class Extensions
        {
            public static string GetDescription<T>(this T value) where T : Enum
            {
                Type type = typeof(T);
                string name = Enum.GetName(type, value);
                if (name != null)
                {
                    FieldInfo field = type.GetField(name);
                    if (field != null)
                        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attr)
                            return attr.Description;
                }
                return null;
            }
        }
    }

}
