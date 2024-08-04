public interface IPool
{
    void Return(CollectableObject collectable);
    
    CollectableObject Get();
}
