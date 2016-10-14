namespace TeduCore.Model.Interfaces
{
    public interface ICreationAudited<TKey> : IHasCreationTime
    {
        TKey CreatorUserId { get; set; }
    }
}