using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace Rinha;

[Route("clientes")]
[ApiController]
public class TransactionController : ControllerBase
{
    // private IClientRepository _clientRepository;
    private IClientService _clientService;

    public TransactionController(IClientService clientService) {
        _clientService = clientService;
    }

    [HttpPost("{id}/transacoes")]
    public async Task<IResult> DoTransaction(int id, [FromBody] TransactionDTO transactionDto) {
        return await _clientService.AddTransaction(id, transactionDto);
    }

    [HttpGet("{id}/extrato")]
    public async Task<IResult> GetExtract(int id) {
        return await _clientService.GetClientInfo(id);
    }
}
