using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy") )
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }

    
}
