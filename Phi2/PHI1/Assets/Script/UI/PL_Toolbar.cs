using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PL_Toolbar : MonoBehaviour
{
    public bool PLSelected, Prev;
    public GameObject PLTolbar, PL;
    public InputField Miu, Angle;
    public string input;
  
     private void Start()
     {
         DisablePLTolbar();
     }
  

     /*private void Update()
     {
         if (PLSelected)
             UpdatePLTolbar();
     }*/
     public void EnablePLTolbar()
     {
         PLTolbar.SetActive(true);
         PLProp pl = PL.GetComponent<PLProp>();
         Miu.text = pl.miu.ToString();
         Angle.text = pl.angle.ToString();
         PLSelected = true;
     }

     private void UpdatePLTolbar()
     {
        PLProp pl = PL.GetComponent<PLProp>();
        Miu.text = pl.miu.ToString();
        Angle.text = pl.angle.ToString();
    }
     public void DisablePLTolbar()
     {
         PLTolbar.SetActive(false);
         PLSelected = false;
     }

    public void ReadAngleInput(string s)
    {
        input = s;
        PLProp plp = PL.GetComponent<PLProp>();
        plp.angle = float.Parse(input);
    }

    public void ReadMiuInput(string s)
    {
        input = s;
        PLProp plp = PL.GetComponent<PLProp>();
        plp.miu = float.Parse(input);
    }
}
     

