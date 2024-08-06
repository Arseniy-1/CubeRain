using System;
using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    public event Action<CollectableObject> OnDestroyed;

    public abstract void Activate();

    public void Return()
    {
        OnDestroyed?.Invoke(this);
    }
}
