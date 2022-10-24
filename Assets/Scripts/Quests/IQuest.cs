using System;

public interface IQuest
{
    event Action<IQuest> Completed;
    bool IsCompleted { get; }
    void Reset();
}
