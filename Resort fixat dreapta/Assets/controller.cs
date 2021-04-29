using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    // Start is called before the first frame update
    float v = 500.0f;
    Rigidbody rb;
    public float prevVelocity;
    public float stadiu = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 F = new Vector3(115.0f, 0, 0);
        rb.AddForce(F * v);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(rb.velocity);
        if (stadiu == 0)
        {
            prevVelocity = rb.velocity.x;
        }
       
    }
    void OnCollisionEnter(Collision col)
    {
        /*if (col.gameObject.name == "resort")
        {
            Debug.Log("Colission");
            Debug.Log(scriptResort.stadiu);
            if (stadiu < 2)
            {
                
                //transform.localPosition += new Vector3(0.5f, 0, 0);
                Vector3 F = new Vector3(300.0f * rb.mass, 0, 0);
                rb.AddForce(F);
            }
        


        }*/
    }
}
