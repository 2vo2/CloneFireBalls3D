using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bulletTemplate;
    
    private List<Bullet> _bulletPool = new List<Bullet>();
    private Bullet _bulletToGet;

    private bool PoolActiveSelfCheck()
    {
        var activeBullets = _bulletPool.FindAll(b => b.gameObject.activeSelf);

        return activeBullets.Count == 0;
    }
    
    public Bullet GetBullet(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        if (_bulletPool.Count > 0 && PoolActiveSelfCheck())
        {
            _bulletToGet = _bulletPool[Random.Range(0, _bulletPool.Count)];
            ResetBulletProperties(spawnPosition, spawnRotation);
            _bulletToGet.gameObject.SetActive(true);
        }
        else
        {
            _bulletToGet = Instantiate(_bulletTemplate, spawnPosition, spawnRotation, transform);
            _bulletPool.Add(_bulletToGet);
        }
        
        return _bulletToGet; 
    }

    private void ResetBulletProperties(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        _bulletToGet.Rigidbody.velocity = Vector3.zero;
        _bulletToGet.transform.position = spawnPosition;
        _bulletToGet.transform.rotation = spawnRotation;
    }
}
