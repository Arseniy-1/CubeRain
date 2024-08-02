using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _poolCapacity;
    [SerializeField] private CollectableObject _objectPrefab;

    private Queue<CollectableObject> _objects = new Queue<CollectableObject>();

    public int ActiveCount { get; private set; } = 0;

    private void Awake()
    {
        for (int i = 0; i < _poolCapacity; i++)
        {
            _objects.Enqueue(Instantiate(_objectPrefab));
        }

        foreach (CollectableObject obj in _objects)
        {
            obj.gameObject.SetActive(false);
            obj.Initialize(this);
        }
    }
    public void Reset()
    {
        foreach (CollectableObject obj in _objects)
        {
            obj.gameObject.SetActive(false);
        }
    }

    public CollectableObject Get()
    {
        if (_objects.Count == 0)
            ExpandPool();

        CollectableObject newObj = _objects.Dequeue();
        newObj.transform.rotation = Quaternion.identity;
        newObj.gameObject.SetActive(true);
        ActiveCount++;

        return newObj;
    }

    public void Return(CollectableObject obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
        ActiveCount--;
    }

    private void ExpandPool()
    {
        CollectableObject obj = Instantiate(_objectPrefab);
        obj.Initialize(this);
        _objects.Enqueue(obj);
    }
}