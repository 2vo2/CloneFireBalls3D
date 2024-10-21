using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _sizeView;
    [SerializeField] private Tower _tower;

    private void OnEnable() 
    {
        _tower.SizeUpdate += OnSizeView;
    }

    private void OnDisable()
    {
        _tower.SizeUpdate -= OnSizeView;
    }

    private void OnSizeView(int towerSize)
    {
        _sizeView.text = towerSize.ToString();
    }
}