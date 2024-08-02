using UnityEngine;
using System.Collections;

public class BombDisapearer : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;
    [SerializeField] private Renderer _renderer;

    private float _displayDelay = 0.05f;
    private float _currentTime = 0;

    private Color _startColor;
    private Color _targetColor;

    private Coroutine _disapearing;

    private void Awake()
    {
        _startColor = _renderer.material.color;
        _startColor.a = 1;

        _targetColor = _startColor;
        _targetColor.a = 0;
    }

    public void Disapear()
    {
        if(_disapearing != null)
            StopCoroutine(_disapearing);

        _disapearing =  StartCoroutine(SmoothDisapearing());
    }

    private IEnumerator SmoothDisapearing()
    {
        float maxAlpha = 1;
    
        _currentTime = 0;
        _renderer.material.color = _startColor;

        while (_currentTime < _bomb.DetonateDelay)
        {
            _currentTime += _displayDelay;

            _renderer.material.color = Color.Lerp(_renderer.material.color, _targetColor, maxAlpha / (_bomb.DetonateDelay / _displayDelay));
            yield return new WaitForSeconds(_displayDelay);
        }

    }
}
