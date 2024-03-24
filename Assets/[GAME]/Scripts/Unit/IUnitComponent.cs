public interface IUnitComponent
{
    bool IsActived { get; }

    void Init(Unit unit);
    void Activate();
    void Deactivate();
}