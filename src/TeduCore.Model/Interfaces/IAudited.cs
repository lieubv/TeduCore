namespace TeduCore.Model.Interfaces
{
    public interface IAudited<TKey> : ICreationAudited<TKey>, IModificationAudited<TKey>
    {
    }
}