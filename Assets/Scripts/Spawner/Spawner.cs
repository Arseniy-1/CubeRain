using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private TextMeshProUGUI _activeObjectCountView;
    [SerializeField] private TextMeshProUGUI _objectCountView;

    private int _count;

    private void Update()
    {
        ShowInfo();
    }

    public void ShowInfo()
    {
        _activeObjectCountView.text = _pool.ActiveCount.ToString();
        _objectCountView.text = _count.ToString();
    }

    public void Spawn(Vector3 position)
    {
        _count++;
        CollectableObject obj = _pool.Get();
        obj.transform.position = position;
        obj.Activate();
    }
}
