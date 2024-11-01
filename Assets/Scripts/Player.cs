using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _hp = 10;
    [SerializeField] private float _shootForce = 15;

    [SerializeField] private GameObject _bullet = null;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shootForce);
    }

    public void Die()
    {

    }
}
