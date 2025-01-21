using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Inheritance
public class Cowboy : Enemy
{
    public float shootRate = 2;
    private bool isShooting = false;
    public Transform shootingPoint;
    public GameObject projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
        if (!isShooting)
        {
            StartCoroutine(CanShoot());
        }
    }

    // Abstraction
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, transform.rotation);
        projectile.transform.Rotate( 90, 0, 0);
        Destroy(projectile, 5);
    }

    private IEnumerator CanShoot()
    {
        isShooting = true;
        yield return new WaitForSeconds(shootRate);
        Shoot();
        isShooting = false;
    }




}
