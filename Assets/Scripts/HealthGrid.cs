using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGrid : MonoBehaviour
{
    [SerializeField] private List<Image> _grid = null;

    public void UpdateHP(int value)
    {
        foreach (Image image in _grid)
            image.enabled = false;

        for (int i = 0; i < value; ++i)
            _grid[i].enabled = true;
    }
}
