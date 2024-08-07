using TMPro;
using UnityEngine;

public class SpawnerInfoView<T> : MonoBehaviour where T : CollectableObject
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private TextMeshProUGUI _activeObjectCountView;
    [SerializeField] private TextMeshProUGUI _objectCountView;

    private void OnEnable()
    {
        _spawner.ActiveObjectCountChanged += ShowActiveObjectsCount;
        _spawner.ObjectCountChanged += ShowObjectsCount;
    }

    private void OnDisable()
    {
        _spawner.ActiveObjectCountChanged -= ShowActiveObjectsCount;
        _spawner.ObjectCountChanged -= ShowObjectsCount;
    }

    private void ShowActiveObjectsCount(int count)
    {
        _activeObjectCountView.text = count.ToString();
    } 

    private void ShowObjectsCount(int count)
    {
        _objectCountView.text = count.ToString();
    }
}
