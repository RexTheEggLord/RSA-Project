using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 2;
    [SerializeField] private int currencyReward = 10;

    private bool isDead = false;
    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage: " + damage);

        health -= damage;
        if (health <= 0 && !isDead)
        {
            EnemySpawner.onEnemyDestroyed.Invoke();
            levelManger.main.GainCurrency(currencyReward);
            Destroy(gameObject);
            isDead = true;
        }
    }




}
