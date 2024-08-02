public interface IReturnable
{
    public void Initialize(ObjectPool objectPool) { }

    public void Return(CollectableObject collectableObject) { }
}
