using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _gameOverPanelText;
    private bool _gameOverFlag=false;
    public TMP_Text timerText;
    [SerializeField] private float _currentTime = 3f;

    
    // Update is called once per frame
    public void Update()
    {
        _currentTime -= 1 * Time.deltaTime;
        timerText.text = Mathf.Round(_currentTime).ToString();
        if (_currentTime <= 0 )
        {
            _gameOverFlag = true;
            if (_gameOverFlag == true)
            {
                _gameOverPanel.SetActive(true);
                _gameOverPanelText.text = "Вы проиграли";
            }
               
            
        }
        
    }
}
