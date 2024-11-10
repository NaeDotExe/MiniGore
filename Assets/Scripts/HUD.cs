using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Timer _timer = null;
    [SerializeField] private HealthGrid _healthGrid = null;

    [SerializeField] private TextMeshProUGUI _timerText = null;
    [SerializeField] private TextMeshProUGUI _scoreText = null;

    private void Start()
    {

    }

    private void Update()
    {
        //        _timerText.text = _timer.Value.ToString();
    }

    public void UpdateScore(int value)
    {
        if (0 <= value && value < 10)
        {
            _scoreText.text = "0000" + value.ToString();
        }
        else if (10 <= value && value < 100)
        {
            _scoreText.text = "000" + value.ToString();
        }
        else if (100 <= value && value < 1000)
        {
            _scoreText.text = "00" + value.ToString();
        }
        else if (1000 <= value && value < 10000)
        {
            _scoreText.text = "0" + value.ToString();
        }
        else
        {
            _scoreText.text = value.ToString();
        }
    }

    public void UpdateHP(int value)
    {
        _healthGrid.UpdateHP(value);
    }
}
