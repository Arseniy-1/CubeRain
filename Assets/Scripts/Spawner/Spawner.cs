using TMPro;
using UnityEngine;

public abstract class Spawner<T> : MonoBehaviour where T : CollectableObject
{
    [SerializeField] private ObjectPool<T> _pool;
    [SerializeField] private TextMeshProUGUI _activeObjectCountView;
    [SerializeField] private TextMeshProUGUI _objectCountView;

    private int _objectCount;

    protected virtual void OnEnable()
    {
        _pool.ObjectCountChanged += ShowInfo;   
    }

    protected virtual void OnDisable()
    {
        _pool.ObjectCountChanged -= ShowInfo;
    }

    public void ShowInfo()
    {
        _activeObjectCountView.text = _pool.ActiveCount.ToString();
        _objectCountView.text = _objectCount.ToString();
    }

    public void PlaceInPool(CollectableObject collectableObject)
    {
        collectableObject.OnDestroyed -= PlaceInPool;
        _pool.Release((T)collectableObject);
    }

    public void Spawn(Vector3 position)
    {
        _objectCount++;
        T obj = _pool.Get();
        obj.OnDestroyed += PlaceInPool;
        obj.transform.position = position;
        obj.Activate();
    }
}
