using System.ComponentModel.DataAnnotations.Schema;

namespace Rinha;

public class ClientModel
{
    [Column("id")]
    public int Id { get; set; }
    [Column("limite")]
    public int Limit { get; set; }
    [Column("balance")]
    public int Balance { get; set; }
}
