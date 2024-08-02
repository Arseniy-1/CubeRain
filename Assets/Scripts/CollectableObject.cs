using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    [SerializeField] protected Returner Returner;

    public void Initialize(ObjectPool pool)
    {
        Returner.Initialize(pool);
    }

    public abstract void Activate();
}
