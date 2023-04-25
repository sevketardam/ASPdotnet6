using ASPLearning.UI.Models.IM;

namespace ASPLearning.UI.IServices
{
    public class OrderService : IOrderService
    {
        private IEmailService emailService;
        public OrderService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void SubmitOrder(SubmitOrderIM model)
        {
            //Siparişten sonra email at
            this.emailService.SendEmail("Ali","Ahmet","Sipariş Tamamlandı");
        }
    }
}
