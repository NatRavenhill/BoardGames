namespace BoardGames.Email
{
    /// <summary>
    /// Options for email sending
    /// </summary>
    public class AuthMessageSenderOptions
    {
        /// <summary>
        /// User of email sender
        /// </summary>
        public string EmailUser { get; set; }

        /// <summary>
        /// Password of email sender
        /// </summary>
        public string EmailPassword { get; set; }
    }
}
