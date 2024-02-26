namespace Rinha;

public interface IClientRepository
{
    Task<ClientModel> SearchUserById(int id);
    Task<List<TransactionsModel>?> SearchLastTransactions(int id);
    Task<List<ResultModel>?> addTransactionAsync(int id, TransactionDTO dto);
}
