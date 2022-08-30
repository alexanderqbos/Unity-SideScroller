using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 25;

    private float xBoundry = -20f;
    private Rigidbody rb;

    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pc = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if(!pc.isGameOver())
        {
            if(!rb)
            {
                Vector3 movement = Vector3.left * speed * Time.deltaTime;
                transform.Translate(movement);
            }   
        }
        if(transform.position.x < xBoundry)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!pc.isGameOver())
        {
            if(rb)
            {
                Vector3 movement = Vector3.left * speed * Time.deltaTime;
                rb.MovePosition(transform.position + movement);
            }
        }
    }
}
