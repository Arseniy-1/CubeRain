using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    [SerializeField] protected Returner Returner;

    public void Initialize(IPool pool)
    {
        Returner.Initialize(pool);
    }

    public abstract void Activate();
}
