using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private Transform _shootPoint;
    
    [Header("Shoot")]
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _delayBetweenShoot;
    
    [Header("Animation")]
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoot;

    private void Update() 
    {
        _timeAfterShoot += Time.deltaTime;

        if(Mathf.Approximately(Time.timeScale, 1))
        {
            if(Input.GetMouseButton(0))
            {
                if(_timeAfterShoot > _delayBetweenShoot)
                {
                    Shoot();
                    transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoot / 2).SetLoops(2, LoopType.Yoyo);
                    _timeAfterShoot = 0;
                }
            }
        }    
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
        bullet.Rigidbody.AddForce(Vector3.forward * _shootForce);
    }
}
