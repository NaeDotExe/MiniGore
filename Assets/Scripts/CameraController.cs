using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _target = null;

    [SerializeField] private float _offset = 10;

    private bool _allowMovement = true;
    
    private void Update()
    {
        if (_allowMovement)
        { 
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = _target.position + new Vector3(0, _offset, -_offset);
    }
}
