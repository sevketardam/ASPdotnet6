namespace ASPLearning.UI.IServices
{
    public interface IEmailService
    {
        /// <summary>
        /// Email Gönderen Servis
        /// </summary>
        /// <param name="to">kime</param>
        /// <param name="from">kimden</param>
        /// <param name="message">mesaj</param>
        void SendEmail(string to,string from,string message);
    }
}
