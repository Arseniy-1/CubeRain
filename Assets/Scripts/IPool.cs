public interface IPool
{
    void Release(CollectableObject collectable);
    
    CollectableObject Get();
}
