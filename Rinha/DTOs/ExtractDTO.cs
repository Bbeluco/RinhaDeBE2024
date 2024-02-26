using System.Numerics;

namespace Rinha;

public class ExtractDTO
{
    public Saldo saldo { get; set; }
    public List<TransactionsModel> ultimas_transacoes { get; set; }
}

public class Saldo
{
    public int total { get; set; }
    public DateTime data_extrato { get; set; }
    public int limite { get; set; }
}