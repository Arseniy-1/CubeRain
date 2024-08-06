using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class ObjectPool<T> where T : CollectableObject
{
    [SerializeField] private int _poolCapacity;
    [SerializeField] private T _objectPrefab;

    private Queue<T> _objects = new Queue<T>();

    public event Action ObjectCountChanged;

    public int ActiveCount { get; private set; } = 0;

    private void Awake()
    {
        for (int i = 0; i < _poolCapacity; i++)
            ExpandPool();
    }

    public T Get()
    {
        if (_objects.Count == 0)
            ExpandPool();

        T newObj = _objects.Dequeue();
        newObj.transform.rotation = Quaternion.identity;
        newObj.gameObject.SetActive(true);

        ActiveCount++;
        ObjectCountChanged?.Invoke();

        return newObj;
    }

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
        ActiveCount--;
        ObjectCountChanged?.Invoke();
    }

    private void ExpandPool()
    {
        T obj = Object.Instantiate(_objectPrefab);
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }
}