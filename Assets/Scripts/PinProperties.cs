
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PinProperties : MonoBehaviour
{
  
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _gameOverText;
    [SerializeField] private TMP_Text _pin1;
    [SerializeField] private TMP_Text _pin2;
    [SerializeField] private TMP_Text _pin3;

    private int _minBorderPinValue = 0;
    private int _maxBorderPinValue = 10;

    private int _pin1Value;
    private int _pin2Value;
    private int _pin3Value;

    private int _pin1WinValue;
    private int _pin2WinValue;
    private int _pin3WinValue;
    // Start is called before the first frame update
    void Start()
    {
        InitializatePins();

    }

    // Update is called once per frame
    void Update()
    {
        ValueBorderCheck();
        DisplayPins();
        CheckWinPins();
    }
    //Отображение Пинов
    private void ValueBorderCheck()
    {
        if (_pin1Value < 0)
        {
            _pin1Value = 10;
        }
        else if (_pin1Value > 10)
        {
            _pin1Value = 0;
        }
        if (_pin2Value < 0)
        {
            _pin2Value = 10;
        }
        else if (_pin2Value > 10)
        {
            _pin2Value = 0;
        }
        if (_pin3Value < 0)
        {
            _pin3Value = 10;
        }
        else if (_pin3Value > 10)
        {
            _pin3Value = 0;
        }
    }
    private void InitializatePins()
    {
        _pin1WinValue = Random.Range(_minBorderPinValue, _maxBorderPinValue);
        _pin2WinValue = Random.Range(_minBorderPinValue, _maxBorderPinValue);
        _pin3WinValue = Random.Range(_minBorderPinValue, _maxBorderPinValue);

        _pin1Value = Random.Range(_minBorderPinValue, _maxBorderPinValue);
        _pin2Value = Random.Range(_minBorderPinValue, _maxBorderPinValue);
        _pin3Value = Random.Range(_minBorderPinValue, _maxBorderPinValue);



        Debug.Log($"Победная комбинакция пинов: {_pin1WinValue},{_pin2WinValue},{_pin3WinValue}");

    }
    private void DisplayPins()
    {
        _pin1.text = _pin1Value.ToString();
        _pin2.text = _pin2Value.ToString();
        _pin3.text = _pin3Value.ToString();
    }
    private void CheckWinPins()
    {
        if (_pin1Value == _pin1WinValue && _pin2Value == _pin2WinValue && _pin3Value == _pin3WinValue)
        {
            _gameOverPanel.SetActive(true);
            _gameOverText.text = "Вы выйграли";
            
        }
    }


    //

    //Инструменты
    public void DrillUse()
    {
        _pin1Value++;
        _pin2Value--;
    }
    public void HammerUse()
    {
        _pin1Value--;
        _pin2Value += 2;
        _pin3Value--;

    }
    public void LockPickUse()
    {
        _pin1Value--;
        _pin2Value++;
        _pin3Value++;
    }

    public void MasterKeyUse()
    {
        _pin1Value = _pin1WinValue;
        _pin2Value = _pin2WinValue;
        _pin3Value = _pin3WinValue;

    }
    //
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
