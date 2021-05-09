using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLProp : MonoBehaviour
{
    public float miu;
    public float angle;
    private float angleprev, miuprev, R;
    Quaternion Q;
    // Start is called before the first frame update
    void Start()
    {
        Q.eulerAngles = new Vector3(0, 0, 30);
        transform.rotation = Q;
    }

    // Update is called once per frame
    void Update()
    {
        angleprev = transform.eulerAngles.z;
        Q.eulerAngles = new Vector3(0, 0, (int)angle * -1);
        transform.rotation = Q;
    }
    private void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        R = (float)(System.Math.Sin(angle)) - (float)(miu * System.Math.Cos(angle));
        R *= rb.mass;
        rb.AddForce(Vector3.left * R);
    }
}
