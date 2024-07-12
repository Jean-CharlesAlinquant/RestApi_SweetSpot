namespace InstaPay.Api.Domain.Interfaces;

public interface IRepository<T>
{
    Task SaveAsync(T message);
    Task<T?> GetByIdAsync(string transactionId);
}