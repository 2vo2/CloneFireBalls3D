using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;

    private void Start() 
    {
        transform.DORotate(new Vector3(0, 360, 0), _animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);    
    }
}
