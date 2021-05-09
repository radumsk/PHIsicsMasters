using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float v = 0f;
    Rigidbody rb;
    public float prevVelocity;
    public float stadiu = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
      

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stadiu == 0)
            //Debug.Log(rb.velocity);
            //rb.AddForce(Vector3.right * v);
            prevVelocity = -rb.velocity.x;
       
    }
   

}
