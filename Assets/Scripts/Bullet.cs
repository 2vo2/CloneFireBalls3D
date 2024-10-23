using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;
    [SerializeField] private float _delayToDestroy;
    
    public Rigidbody Rigidbody => _rigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Block block))
        {
            block.Break();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.TryGetComponent(out Obstacle _)) 
            Bounce(other.contacts[0].normal);    
    }

    private void Bounce(Vector3 normal)
    {
        _rigidbody.velocity = Vector3.zero;
        
        var bounceDirection = Vector3.Cross(normal, Vector3.up);
        _rigidbody.AddExplosionForce(_bounceForce, bounceDirection, _bounceRadius);

        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(_delayToDestroy);
        
        gameObject.SetActive(false);
    }
}
