using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject asteroid;
    float repeatTime = 3.0f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnEnemies", 2.0f, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time>10.0f)
        {
            repeatTime--;
            time =0;
        }
    }
    void SpawnEnemies()
    {
        transform.position = new Vector3(Random.Range(-8, 8), 6, 0);
        GameObject enemy = Instantiate(asteroid, transform.position, Quaternion.identity);
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down;
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "asteroid")
        {

            Destroy(collision.gameObject);
        }
    }
    */
}
