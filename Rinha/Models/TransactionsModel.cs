using Microsoft.EntityFrameworkCore;

namespace Rinha;

[Keyless]
public class TransactionsModel
{
    public int Valor { get; set; }
    public string Tipo { get; set; }
    public string Descricao { get; set; }
    public DateTime Realizada_em { get; set; }
}
