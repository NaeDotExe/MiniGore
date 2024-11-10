using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeDuration = 5f;

    private float _elapsed = 0;

    private void Start()
    {

    }

    private void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed >= _lifeDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
