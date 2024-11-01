using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    [SerializeField] private Timer _timer = null;

    [SerializeField] private TextMeshProUGUI _timerText = null;

    private void Start()
    {

    }

    private void Update()
    {
        _timerText.text = _timer.Value.ToString();
    }
}
