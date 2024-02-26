namespace Rinha;

public interface IClientService
{
    public Task<IResult> AddTransaction(int id, TransactionDTO dto);
    Task<IResult> GetClientInfo(int id);
}
