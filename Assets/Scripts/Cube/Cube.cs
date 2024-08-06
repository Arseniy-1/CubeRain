using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

public class Cube : CollectableObject
{
    [SerializeField] private Painter _painter;
    [SerializeField] private Rigidbody _rigidbody;

    private bool _isTouched;

    private int _maxDelay = 5;
    private int _minDelay = 2;

    public static Action<Vector3> OnDisabled;

    public override void Activate()
    {
        _rigidbody.velocity = Vector3.zero;
        _isTouched = false;
        _painter.ChangeToDefaultColor();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if (_isTouched)
                return;

            _painter.ChangeColor();
            _isTouched = true;

            StartCoroutine(ReturnWithDelay());
        }
    }

    private IEnumerator ReturnWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        
        Return();
        OnDisabled.Invoke(transform.position);
    }
}
