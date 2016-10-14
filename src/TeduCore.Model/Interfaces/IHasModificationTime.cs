using System;

namespace TeduCore.Model.Interfaces
{
    public interface IHasModificationTime
    {
        DateTime? LastModificationTime { get; set; }
    }
}