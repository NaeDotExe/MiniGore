using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotSpeed = 10f;

    private bool _allowMovement = true;

    public bool AllowMovement
    {
        get { return _allowMovement; }
        set { _allowMovement = value; }
    }

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
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            transform.rotation = newRotation;
        }
    }
}
