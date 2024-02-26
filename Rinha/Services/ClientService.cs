using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Rinha;

public class ClientService : IClientService
{
    private IClientRepository _clientRepository;
    private List<int> _limitsClients = [100000, 80000, 1000000, 10000000, 500000];

    public ClientService(IClientRepository clientRepository) {
        _clientRepository = clientRepository;
    }

    public async Task<IResult> AddTransaction(int id, TransactionDTO dto) {
        if(id < 1 || id > 5) {
            return Results.NotFound();
        }
        if(dto.Tipo != "d" 
        && dto.Tipo != "c" 
        || dto.Descricao.Length > 10 || dto.Descricao.Length <= 0 
        || dto.Valor <= 0)
        {
            return Results.UnprocessableEntity();
        }

        List<ResultModel>? transaction = await _clientRepository.addTransactionAsync(id, dto);
        if(transaction[0].Saldo == null) {
            return Results.UnprocessableEntity();
        }

        TransactionResponseDTO transactionResponse = new TransactionResponseDTO
        {
            limite = _limitsClients[id-1],
            saldo = (int)transaction[0].Saldo
        };

        return Results.Ok(transactionResponse);
    }

    public async Task<IResult> GetClientInfo(int id) {
        if(id < 1 || id > 5) {
            return Results.NotFound();
        }
        ClientModel client = await _clientRepository.SearchUserById(id);
        List<TransactionsModel>? transactions = await _clientRepository.SearchLastTransactions(id);

        ExtractDTO extractDTO = new ExtractDTO {
            saldo = new Saldo{ data_extrato = DateTime.UtcNow, limite = client.Limit, total = client.Balance },
            ultimas_transacoes = transactions
        };
        return Results.Ok(extractDTO);
    }
}
