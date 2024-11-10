using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _retry = null;
    [SerializeField] private Button _quit = null;

    [SerializeField] private TextMeshProUGUI _scoreText = null;

    private void Start()
    {
        _retry.onClick.AddListener(() => SceneManager.LoadScene("Arena"));
        _quit.onClick.AddListener(Application.Quit);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = string.Format("Score : {0}", score);
    }
    public void UpdateHighScore(int score)
    {

    }
}
