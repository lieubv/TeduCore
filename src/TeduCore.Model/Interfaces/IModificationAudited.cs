namespace TeduCore.Model.Interfaces
{
    public interface IModificationAudited<TKey>
    {
        TKey LastModifierUserId { get; set; }
    }
}