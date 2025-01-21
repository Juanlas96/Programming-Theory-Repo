using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private float rotationSpeed = 100;
    private float livingTime = 5;
    private bool canShoot = true;
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    private Rigidbody playerRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            Shoot();
        }
    }

    // Abstraction
    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);
        playerRb.MoveRotation(playerRb.rotation * deltaRotation);

    
        Vector3 direction = transform.forward * verticalInput * speed * Time.deltaTime;
        playerRb.MovePosition(playerRb.position + direction);
    }

    // Abstraction
    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);
        projectile.transform.Rotate( 90, 0, 0);
        Destroy(projectile, livingTime);
        canShoot = false;
        StartCoroutine(ShootRate());

    }

    private IEnumerator ShootRate()
    {
        yield return new WaitForSeconds(1.4f);
        canShoot = true;
    }
}
