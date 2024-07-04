using InstaPay.Api.Domain;

namespace InstaPay.Api.Services;

public class PaymentsService
{
    private static readonly List<Payment> PaymentsRepository = [];

    public void Create(Payment payment)
    {
        // store the payment in the database
        PaymentsRepository.Add(payment);
    }

    public Payment? Get(Guid productId)
    {
        // pull the product from the database
        return PaymentsRepository.Find(x => x.Id == productId);
    }
}