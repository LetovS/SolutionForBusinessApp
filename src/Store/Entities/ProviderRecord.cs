using Store.Entities.Base;

namespace Store.Entities;

public class ProviderRecord : BaseEntity
{
    public ProviderRecord(int id, string name) : base(id)
    {
        Name = name;
    }

    /// <summary>
    /// Название провайдера
    /// </summary>
    public string Name { get; set; }

    public virtual ICollection<OrderRecord> Orders { get; set; }
}
