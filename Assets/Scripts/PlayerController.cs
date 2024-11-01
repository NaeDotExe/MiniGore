using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotSpeed = 10f;

    private bool _allowMovement = true;

    private void Update()
    {
        if (_allowMovement)
        {
            UpdatePosition();
            UpdateRotation();
        }
    }

    private void UpdatePosition()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * _moveSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * _moveSpeed;

        Vector3 position = transform.position + new Vector3(x, 0, z);

        transform.position = position;
    }
    private void UpdateRotation()
    {
        // horizontal -> Y rotation

        float y = Input.GetAxis("Horizontal") * Time.deltaTime * _rotSpeed;

        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + y, transform.rotation.z) ;
    }
}
