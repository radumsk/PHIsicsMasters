using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBack : MonoBehaviour
{
    // Start is called before the first frame update\
    private Vector3 pozvector, scalevector;
    Rigidbody rb;
    void Start()
    {
        
    }

  public void RunActive()
    {
        pozvector = rb.transform.position;
        scalevector = rb.transform.localScale;
    }
    // Update is called once per frame
    public void RunStop()
    {
        rb.transform.position = pozvector;
        rb.transform.localScale = scalevector;
    }
    void Update()
    {
        
    }
}
