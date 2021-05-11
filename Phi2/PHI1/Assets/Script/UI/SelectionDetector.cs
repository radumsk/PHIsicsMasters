using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SelectionDetector : MonoBehaviour
{
 
    [SerializeField] private Material original, highlighted;
    private MeshRenderer objrend;
    public bool IsSelected;
    Rigidbody rb;
    private bool Delon;
    public GameObject DelButton;

    private void Awake()
    {
        objrend = GetComponent<MeshRenderer>();
        objrend.material = original;
        DelButton = GameObject.Find("Delete_Button");
    }

    public void Clicked()
    {
        IsDeleteOn delbutton = DelButton.GetComponent<IsDeleteOn>();
        Delon = delbutton.DeleteIsSelected;
        if (Delon)
        {
            objrend.gameObject.SetActive(false);
            Debug.Log(Delon);
        }
        else
        {
            if (!IsSelected)
                objrend.material = original;
            else
            {
                objrend.material = highlighted;
            }
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
