using System;

namespace Obviously.SemanticTypes.Consumer.NetCoreConsole
{
    [SemanticType(typeof(string))]
    public partial class EmailAddressWithValidation
    {
        public static bool IsValid(string value)
        {
            return value.Contains('@', StringComparison.OrdinalIgnoreCase);
        }
    }
}
