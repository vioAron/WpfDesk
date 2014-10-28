using System;
using System.ComponentModel;
using System.Diagnostics;
using WpfDesk.Model;

namespace WpfDesk.TypeConverters
{
    public class ClientTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                var s = (string)value;

                var clientTokens = s.Split(',');
                try
                {
                    return new Client
                    {
                        Id = clientTokens[0],
                        Description = clientTokens[1]
                    };
                }
                catch (Exception)
                {
                    Trace.Write("Client was not correctly defined!");
                    return null;
                }
            }
            else
            {
                return base.ConvertFrom(context, culture, value);
            }
        }
    }
}
