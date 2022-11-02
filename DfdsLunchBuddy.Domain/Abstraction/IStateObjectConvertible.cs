namespace Dfds.Logistics.Packaging.Manager.Domain.Abstrations
{
    public interface IStateObjectConvertible<out TState>
        where TState : class, new()
    {
        TState ToSnapshot();
    }
}