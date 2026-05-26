using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTime = 2f;

    [SerializeField] private Rigidbody2D rb;



    public void SetTarget(Transform _target)
    {
        if (!_target) return;
        target = _target;
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
        Destroy(gameObject, lifeTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         collision.gameObject.GetComponent<enemyHealth>().TakeDamage(damage);
        Destroy(gameObject);
    }

}
