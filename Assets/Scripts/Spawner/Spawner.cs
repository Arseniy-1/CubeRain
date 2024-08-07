using System;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : CollectableObject
{
    [SerializeField] protected ObjectPool<T> Pool;
    [SerializeField] private string _text;

    public event Action<int> ActiveObjectCountChanged;
    public event Action<int> ObjectCountChanged;

    protected virtual void OnEnable()
    {
        Pool.ObjectCountChanged += ShowInfo;
    }

    protected virtual void OnDisable()
    {
        Pool.ObjectCountChanged -= ShowInfo;
    }

    public void PlaceInPool(CollectableObject collectableObject)
    {
        collectableObject.OnDestroyed -= PlaceInPool;
        Pool.Release((T)collectableObject);
    }

    private void ShowInfo()
    {
        ActiveObjectCountChanged?.Invoke(Pool.ActiveObjectCount);
        ObjectCountChanged?.Invoke(Pool.ObjectCount);
    }
}
