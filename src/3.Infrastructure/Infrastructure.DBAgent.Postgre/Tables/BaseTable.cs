using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DBAgent.Postgre.Tables;

public abstract class BaseTable
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
}
