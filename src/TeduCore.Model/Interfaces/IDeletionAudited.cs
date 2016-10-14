using System;

namespace TeduCore.Model.Interfaces
{
    public interface IDeletionAudited<TKey>
    {
        TKey DeleterUserId { get; set; }

        DateTime? DeletionTime { get; set; }
    }
}