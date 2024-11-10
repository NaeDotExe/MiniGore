using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _hp = 3;
    [SerializeField] private float _shootForce = 15;
    [SerializeField] private float _delayBetweenShoots = 0.1f;
    [SerializeField] private float _invicibilityDuration = 5f;
    [SerializeField] private PlayerController _controller = null;

    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private MeshRenderer _renderer = null;
    [SerializeField] private Color _normalColor = Color.white;
    [SerializeField] private Color _hitColor = Color.red;

    private bool _allowControl = true;
    private bool _isInvicible = false;
    private float _elapsed = 0f;
    private int _score = 0;

    public int Score
    {
        get { return _score; }
    }

    public UnityEvent<int> OnKilled = new UnityEvent<int>();
    public UnityEvent<int> OnHit = new UnityEvent<int>();

    private void Update()
    {
        if (!_allowControl)
        {
            return;
        }

        AutoShoot();
    }
    private void AutoShoot()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed >= _delayBetweenShoots)
        {
            _elapsed = 0f;
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _shootForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("ENEMY!");

            Enemy enemy = collision.transform.gameObject.GetComponent<Enemy>();
            if (enemy == null)
            {
                return;
            }

            TakeDamage(1);
        }
    }

    private void TakeDamage(int value)
    {
        if (_isInvicible)
            return;

        _hp -= value;
        if (_hp <= 0)
        {
            _hp = 0;

            Die();
        }

        OnHit.Invoke(_hp);
        StartCoroutine(OnHitCoroutine());
    }

    public void Die()
    {
        Debug.Log("PLAYER IS DEAD");

        _allowControl = false;
        _controller.AllowMovement = false;

        OnKilled.Invoke(_score);
    }

    public void UpdateScore(int value)
    {
        _score += value;
    }

    private IEnumerator OnHitCoroutine()
    {
        _isInvicible = true;
        _renderer.material.color = _hitColor;

        yield return new WaitForSeconds(_invicibilityDuration);

        _isInvicible = false;
        _renderer.material.color = _normalColor;
    }
}
