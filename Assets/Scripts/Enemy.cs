using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp = 5;
    [SerializeField] private int _value = 50;
    [SerializeField] private float _moveSpeed = 3.5f;
    [SerializeField] private float _invicibilityDuration = 1.5f;
    [SerializeField] private Material _onHitMat = null;
    [SerializeField] private Material _defaultMat = null;
    [SerializeField] private MeshRenderer _renderer = null;
    [SerializeField] private NavMeshAgent _navMeshAgent = null;

    private bool _isInvicible = false;
    private Player _target = null;

    public UnityEvent OnKilled = new UnityEvent();

    private void Start()
    {
        _target = FindObjectOfType<Player>();
        _navMeshAgent.speed = _moveSpeed;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (_isInvicible)
            return;

        _hp -= damage;
        if (_hp <= 0)
        {
            GameManager.Instance.EnemyKilled(_value);
            OnKilled.Invoke();

            Destroy(gameObject);
        }

        StartCoroutine(OnHitCoroutine());
    }

    private IEnumerator OnHitCoroutine()
    {
        _renderer.material = _onHitMat;
        _isInvicible = true;

        yield return new WaitForSeconds(_invicibilityDuration);

        _renderer.material = _defaultMat;
        _isInvicible = false;
    }
}
