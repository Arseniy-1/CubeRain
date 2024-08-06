using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : CollectableObject
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private BombDisapearer _disapearer;

    public float DetonateDelay { get; private set; } = 3;

    public override void Activate()
    {
        StartCoroutine(StartDelayedDetotate());
    }

    private void Detonate()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> barrels = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                barrels.Add(hit.attachedRigidbody);

        return barrels;
    }

    private IEnumerator StartDelayedDetotate()
    {
        _disapearer.Disapear();
        yield return new WaitForSeconds(DetonateDelay);

        Detonate();
        Return();
    }
}
