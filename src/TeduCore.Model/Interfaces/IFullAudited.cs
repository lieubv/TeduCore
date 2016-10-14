namespace TeduCore.Model.Interfaces
{
    public interface IFullAudited<TKey> : IAudited<TKey>, IDeletionAudited<TKey>
    {
    }
}