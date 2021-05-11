using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sphere_Toolbar : MonoBehaviour
{
    public bool BilaSelected, Prev;
    public GameObject SphereToolbar, Sphere;
    public InputField Mass, Velocity;
    private string input;

    private void Start()
    {
        DisableSphereToolbar();
    }

    private void Update()
    {
        if (BilaSelected)
            UpdateSphereToolbar();
    }

    public void EnableSphereToolbar()
    {
        SphereToolbar.SetActive(true);
        Rigidbody rb = Sphere.GetComponent<Rigidbody>();
        Mass.text = rb.mass.ToString();
        Velocity.text = rb.velocity.x.ToString();
        BilaSelected = true;
    }

    public void UpdateSphereToolbar()
    {
        Rigidbody rb = Sphere.GetComponent<Rigidbody>();
        Velocity.text = rb.velocity.x.ToString();
    }
    public void DisableSphereToolbar()
    {
        SphereToolbar.SetActive(false);
        BilaSelected = false;
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);
        Rigidbody rb = Sphere.GetComponent<Rigidbody>();
        rb.mass = float.Parse(input);
    }
}
