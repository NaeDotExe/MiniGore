using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer _timer = null;

    void Start()
    {
        _timer.StartTimer();
    }

    void Update()
    {
        
    }
}
