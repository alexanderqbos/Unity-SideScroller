using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float halfWidth;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        halfWidth = (float) 112.8 / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - halfWidth)
        {
            transform.position += new Vector3(halfWidth, 0, 0);
        }
    }
}
