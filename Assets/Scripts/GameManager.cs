using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Timer _timer = null;
    [SerializeField] private Player _player = null;
    [SerializeField] private HUD _hud = null;

    public UnityEvent<int> OnGameOver = new UnityEvent<int>();

    private void Start()
    {
        _player.OnHit.AddListener(_hud.UpdateHP);

        _timer.StartTimer();


        _player.OnKilled.AddListener(OnGameOver.Invoke);
    }

    public void EnemyKilled(int value)
    {
        _player.UpdateScore(value);

        _hud.UpdateScore(_player.Score);
    }
}
