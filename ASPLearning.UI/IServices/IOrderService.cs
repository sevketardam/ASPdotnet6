using ASPLearning.UI.Models.IM;

namespace ASPLearning.UI.IServices
{
    public interface IOrderService
    {
        void SubmitOrder(SubmitOrderIM model);           
    }
}
