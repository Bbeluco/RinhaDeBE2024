
using Microsoft.EntityFrameworkCore;

namespace Rinha;

public class ClientRepository : IClientRepository
{
    private SystemDbContext _dbContext;

    public ClientRepository(SystemDbContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<ClientModel> SearchUserById(int id)
    {
        return await _dbContext.Clients.FromSql($"SELECT * FROM FindClient({id})").FirstOrDefaultAsync();
    }

    public async Task<List<TransactionsModel>?> SearchLastTransactions(int id) {
        return await _dbContext.Transactions.FromSqlRaw($"SELECT valor, tipo, descricao, realizada_em FROM transactions{id} ORDER BY realizada_em DESC LIMIT 10 FOR UPDATE").ToListAsync();
    } 

    public async Task<List<ResultModel>?> addTransactionAsync(int id, TransactionDTO dto) {
        var r = await _dbContext.ResultBalance.FromSql($"SELECT * FROM add_transaction({id}, {dto.Valor}, {dto.Tipo}, {dto.Descricao})")
            .ToListAsync();
        return r;
    }
}
