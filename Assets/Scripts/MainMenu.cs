using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _start = null;
    [SerializeField] private Button _quit = null;

    private void Start()
    {
        _start.onClick.AddListener(() => SceneManager.LoadScene("Arena"));
        _quit.onClick.AddListener(Application.Quit);
    }
}
