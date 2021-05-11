using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class IsDeleteOn : MonoBehaviour
{
    // Start is called before the first frame update
    public bool DeleteIsSelected;
    void Start()
    {
        DeleteIsSelected = false;
    }

    public void ChangeStatus()
    {
        DeleteIsSelected = !DeleteIsSelected;
    }
    // Update is called once per frame
    void Update()
    {
        if (DeleteIsSelected)
        {
            
        }
    }
}
