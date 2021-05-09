using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float z;
    private Vector3 dist;
   
    private void Start()
    {
        z = Camera.main.WorldToScreenPoint(transform.position).z;
    }
    void OnMouseDrag()
    {
        Vector3 screen_position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        Vector3 world_position = Camera.main.ScreenToWorldPoint(screen_position);
        transform.position = world_position+dist;
    }
    private void OnMouseDown()
    {
        Vector3 screen_position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, z);
        Vector3 world_position = Camera.main.ScreenToWorldPoint(screen_position);
        dist = transform.position - world_position;
    }
    
    

}
