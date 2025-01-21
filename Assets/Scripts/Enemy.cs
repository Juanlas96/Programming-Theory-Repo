using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    protected Rigidbody enemyRb;
    protected GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.Find("Player");
        //enemyRb = GetComponent<Rigidbody>();
    }

    // Abstraction
    protected virtual void MoveEnemy()
    {
        transform.LookAt(player.transform);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);
    }

}
