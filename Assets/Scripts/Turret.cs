using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;

public class Turret : MonoBehaviour
{
    [SerializeField] private LayerMask enemymask;
    [SerializeField] private Transform turrertRotationPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;





    [SerializeField] private float TargetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float fireRate = 1f;


    private Transform target;
    private float timeUntilfire = 0f;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        } 
        RotateTowardsTarget();

        if (!CheckTargetIsRange())
            {
            target = null;
        } else
        {
            timeUntilfire += Time.deltaTime;
            if (timeUntilfire >= 1f / fireRate)
            {
                Shoot();
                timeUntilfire = 0f;
            }
        }
    }

    private void Shoot()
    {
 
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position,Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(target);

    }
    private void FindTarget()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, TargetingRange, (Vector2)transform.position, 0f);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    
    private bool CheckTargetIsRange()
    {
        return Vector2.Distance(target.position, transform.position)<= TargetingRange;
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turrertRotationPoint.rotation = Quaternion.RotateTowards(turrertRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward,TargetingRange);
    }

}
