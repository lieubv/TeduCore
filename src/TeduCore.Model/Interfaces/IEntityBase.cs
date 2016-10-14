namespace TeduCore.Model.Interfaces
{
    public interface IEntityBase<TKey>
    {
        TKey ID { set; get; }
    }
}