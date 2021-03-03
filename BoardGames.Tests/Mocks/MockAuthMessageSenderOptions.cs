using BoardGames.Email;
using Microsoft.Extensions.Options;

namespace BoardGames.Tests.Mocks
{
    /// <summary>
    /// Mock AuthMessageSenderOptions for testing
    /// </summary>
    public class MockAuthMessageSenderOptions : IOptions<AuthMessageSenderOptions>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MockAuthMessageSenderOptions()
        {
            Value = new AuthMessageSenderOptions()
            {
                EmailUser = "test1@test.com"
            };
        }

        /// <summary>
        /// Options
        /// </summary>
        public AuthMessageSenderOptions Value { get; }
    }
}
