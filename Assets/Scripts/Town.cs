using UnityEngine;

// Inheritance
public class Town : Enemy
{

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
    }

    // Polymorphism
    protected override void MoveEnemy()
    {
        transform.LookAt(player.transform);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(transform.position + lookDirection * speed * Time.deltaTime, ForceMode.Acceleration);
    }
}
