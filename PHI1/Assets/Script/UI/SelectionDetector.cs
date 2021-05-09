using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionDetector : MonoBehaviour
{
 
    [SerializeField] private Material original, highlighted;
    private MeshRenderer objrend;
    public bool IsSelected;
    Rigidbody rb;
    

    private void Start()
    {
        objrend = GetComponent<MeshRenderer>();
        objrend.material = original;
    }

    public void Clicked()
    {
        if (!IsSelected)
            objrend.material = original;
        else
        {
            objrend.material = highlighted;
        }
    }
    void Change()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.down * 90 * Time.deltaTime);
        }
    }
}
