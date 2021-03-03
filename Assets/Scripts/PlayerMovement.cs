using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(HorizontalInput*Time.deltaTime*speed,0,0);
        Vector2 MaxPosition = new Vector2(8.08f, transform.position.y);
        Vector2 MinPosition = new Vector2(-8.08f, transform.position.y);
        if(transform.position.x>8.08f)
        {
            transform.position = MaxPosition;
        }
        else if(transform.position.x<-8.08f)
        {
            transform.position = MinPosition;
        }

        FireBullet();
    }

    private void FireBullet()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {

            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + offset, 0);
            Instantiate(bullet, bullet.transform.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="asteroid")
        {
            Destroy(gameObject);
        }
    }
}
