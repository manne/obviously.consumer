using System;
using System.Threading.Tasks;
using Obviously.SemanticTypes.Generator;

namespace Obviously.SemanticTypes.Consumer.NetCoreConsole
{
    public static class Program
    {
        public static async Task Main()
        {
            await Console.Out.WriteLineAsync("Hello! Please enter your email address");
            var enteredEmailAddressOne = await Console.In.ReadLineAsync();
            var mailOne = new EmailAddress(enteredEmailAddressOne);
            await Console.Out.WriteLineAsync($"You entered '{(string)mailOne}'");

            await Console.Out.WriteLineAsync("Hello! Please enter your email address, the address will be checked for being well-formed");
            var enteredEmailAddressTwo = await Console.In.ReadLineAsync();
            try
            {
                var mailTwo = new EmailAddressWithValidation(enteredEmailAddressTwo);
                await Console.Out.WriteLineAsync($"You entered a well-formed '{(string)mailTwo}'");
            }
            catch (ArgumentException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                await Console.Out.WriteLineAsync($"You entered a not well-formed email address. Parameter: {e.ParamName}. Exception message: {e.Message}");
                Console.ResetColor();
            }
        }
    }

    [SemanticType(typeof(string))]
    public partial class EmailAddress { }

    [SemanticType(typeof(string))]
    public partial class EmailAddressWithValidation
    {
        public static bool IsValid(string value)
        {
            return value.Contains('@', StringComparison.OrdinalIgnoreCase);
        }
    }
}
