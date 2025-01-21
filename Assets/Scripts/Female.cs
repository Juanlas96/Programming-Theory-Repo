using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Inheritance
public class Female : Enemy
{
    private float dashSpeed = 6;
    private float dashRate = 4;
    private bool isDashing = false;
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
        if(!isDashing)
        {
            StartCoroutine(DashWait());
        }

    }
    
    // Abstraction
    private void Dash()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * dashSpeed, ForceMode.Impulse);
    }

    private IEnumerator DashWait()
    {
        isDashing = true;
        yield return new WaitForSeconds(dashRate);
        Dash();
        isDashing = false;
    }
}
