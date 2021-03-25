using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
 
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
