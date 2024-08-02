using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private MeshRenderer _meshRenderer;

    public void ChangeColor()
    {
        Material randomMaterial = _meshRenderer.material;

        while (randomMaterial.color == _meshRenderer.material.color)
            randomMaterial = _materials[Random.Range(0, _materials.Count)];

        _meshRenderer.material = randomMaterial;
    }

    public void ChangeToDefaultColor()
    {
        _meshRenderer.material = _defaultMaterial;
    }
}
