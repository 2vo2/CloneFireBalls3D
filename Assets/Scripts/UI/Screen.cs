using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _button;

    private void OnEnable() 
    {
        _tower.TowerDestroy += OnTowerDestroy;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable() 
    {
        _tower.TowerDestroy -= OnTowerDestroy;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnTowerDestroy()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _button.interactable = true;
    }

    private void OnButtonClick()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
