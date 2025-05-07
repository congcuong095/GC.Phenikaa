using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DBAgent.Postgre.Tables;

public abstract class BaseTable
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Column("CREATED_AT")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("UPDATED_AT")]
    public DateTimeOffset? UpdatedAt { get; set; }

    [Column("DELETED_AT")]
    public DateTimeOffset? DeletedAt { get; set; }
}
