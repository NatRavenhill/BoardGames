using BoardGames.Email;
using BoardGames.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;

namespace BoardGames.Tests.Email
{
    /// <summary>
    /// Tests for the EmailSender class
    /// </summary>
    [TestClass]
    public class TestEmailSender
    {
        private EmailSender sender;

        private string emailString = "test@test.com";
        private MailAddressCollection email;
        private string subject = "Reset Password";
        private string msg = "Hello World!";

        /// <summary>
        /// Constructor
        /// </summary>
        public TestEmailSender()
        {
            sender = new EmailSender(new MockAuthMessageSenderOptions());
            email = new MailAddressCollection() { emailString };
        }

        /// <summary>
        /// Verifies that Create message sets the To field from the email parameter
        /// </summary>
        [TestMethod]
        public void TestCreateMessage_Email()
        {
            //Act
            MailMessage message = sender.CreateMessage(emailString, subject, msg);
            //Assert
            Assert.AreEqual(email.ToString() , message.To.ToString(), "Expected Message To field to be set");
        }

        /// <summary>
        /// Verifies that Create message sets the Subject field from the subject parameter
        /// </summary>
        [TestMethod]
        public void TestCreateMessage_Subject()
        {
            //Act
            MailMessage message = sender.CreateMessage(emailString, subject, msg);
            //Assert
            Assert.AreEqual(subject, message.Subject, "Expected Message Subject field to be set");
        }

        /// <summary>
        /// Verifies that Create message sets the Body field from the message parameter
        /// </summary>
        [TestMethod]
        public void TestCreateMessage_Body()
        {
            //Act
            MailMessage message = sender.CreateMessage(emailString, subject, msg);
            //Assert
            Assert.AreEqual(msg, message.Body, "Expected Message Body parameter to be set");
        }
    }
}
