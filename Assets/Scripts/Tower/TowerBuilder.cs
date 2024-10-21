using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Vector2Int _towerMinMaxSize;
    [SerializeField] private Color[] _colors;
    
    private readonly List<Block> _blocks = new();
    private float _towerSize;

    public List<Block> Build()
    {
        var currentPoint = _buildPoint;

        _towerSize = Random.Range(_towerMinMaxSize.x, _towerMinMaxSize.y);

        for (int i = 0; i < _towerSize; i++)
        {
            var newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return _blocks;
    }
    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x , currentSegment.position.y + _block.transform.localScale.y, _buildPoint.position.z);
    }
}