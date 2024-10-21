using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    public event UnityAction<int> SizeUpdate;
    public event UnityAction TowerDestroy;

    private void Start() 
    {
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdate?.Invoke(_blocks.Count);    
    }

    private void OnBulletHit(Block hitBlock)
    {
        hitBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hitBlock);

        
        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }

        SizeUpdate?.Invoke(_blocks.Count);

        Destroyed(); 
    }

    private void Destroyed()
    {
        if(_blocks.Count == 0)
        {
            TowerDestroy?.Invoke();
        }    
    }
}