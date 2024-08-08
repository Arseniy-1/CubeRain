using TMPro;
using UnityEngine;

public class SpawnerInfoView<T> : MonoBehaviour where T : CollectableObject
{
    [SerializeField] private Spawner<T> _spawner;
    [SerializeField] private TextMeshProUGUI _activeObjectCountView;
    [SerializeField] private TextMeshProUGUI _objectCountView;

    private void OnEnable()
    {
        _spawner.AmountChanged += ShowStats;
    }

    private void OnDisable()
    {
        _spawner.AmountChanged -= ShowStats;
    }

    private void ShowStats()
    {
        _activeObjectCountView.text = _spawner.ActiveObjectCount.ToString();
        _objectCountView.text = _spawner.ObjectCount.ToString();
    }
}
