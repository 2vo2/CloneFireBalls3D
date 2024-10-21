using UnityEngine;

public class DestroyBlockEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystemRenderer _particleSystemRenderer;
    
    public ParticleSystemRenderer ParticleSystemRenderer => _particleSystemRenderer;
}