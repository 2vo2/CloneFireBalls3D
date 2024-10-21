using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private DestroyBlockEffect _destroyEffect;
    [SerializeField] private MeshRenderer _meshRenderer;

    public event UnityAction<Block> BulletHit;

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        var destroyBlockEffect = Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation);
        destroyBlockEffect.ParticleSystemRenderer.material.color = _meshRenderer.material.color;
        Destroy(gameObject);
    }
}