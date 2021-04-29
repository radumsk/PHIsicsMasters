using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scriptResort : MonoBehaviour
{
    // Start is called before the first frame update
    public int stadiu = 0;
    public float dl, change = 0, k = 50082, E;
    const float scaleDif = 0.2f;
    GameObject Sphere;
    Rigidbody sphereRigidBody;
    void Start()
    {
        //k = E * S / l;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(change);
        if (stadiu == 2)
        {
            if (change <= 0)
            {
                sphereRigidBody.transform.position -= new Vector3(0.1f, 0, 0);
                sphereRigidBody.isKinematic = false;
                sphereRigidBody.velocity = new Vector3(0, 0, 0);
                sphereRigidBody.AddForce(new Vector3(-k * dl, 0, 0));
                stadiu = 0;
            }
            else
            {
                sphereRigidBody.transform.position -= new Vector3(scaleDif, 0, 0);
                change -= scaleDif;
                transform.localScale -= new Vector3(scaleDif, 0, 0);
            }
            Sphere.GetComponent<controller>().stadiu = stadiu;
        }
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "Cube")
        {
            Sphere = GameObject.Find(col.gameObject.name);
            sphereRigidBody = Sphere.GetComponent<Rigidbody>();

            //Debug.Log(Sphere.GetComponent<controller>().prevVelocity);
            
            if (stadiu == 0)
            {
                stadiu = 1;
                change = 0;
                dl = Mathf.Sqrt(sphereRigidBody.mass / k) * Sphere.GetComponent<controller>().prevVelocity;
                Vector3 F = new Vector3(300.0f * sphereRigidBody.mass, 0, 0);
                sphereRigidBody.AddForce(F);
            }
            if (stadiu == 1)
            {
                if (change >= dl)
                {
                    stadiu = 2;
                    sphereRigidBody.isKinematic = true;
                }
                else
                {
                    change += scaleDif;
                    transform.localScale += new Vector3(scaleDif, 0, 0);
                    Vector3 F = new Vector3(300.0f * sphereRigidBody.mass, 0, 0);
                    sphereRigidBody.AddForce(F);
                }
            }
            Sphere.GetComponent<controller>().stadiu = stadiu;
            Debug.Log(stadiu);
        }
    }
}
