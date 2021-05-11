using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Caster : MonoBehaviour
{
    private RaycastHit raytarget;
    private GameObject previous; 
    public GameObject SToolbar, PLToolbar;
    private IsDeleteOn delon;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //RaycastHit raytarget;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out raytarget))
            {

                if (previous)
                {
                    SelectionDetector prevselected = previous.GetComponent<SelectionDetector>();
                    prevselected.IsSelected = false;
                    prevselected.Clicked();
                }
                SelectionDetector objselected = raytarget.collider.GetComponent<SelectionDetector>();
                objselected.IsSelected = true;
                objselected.Clicked();

                if (raytarget.collider.name == "to_save_bila")
                {
                    Sphere_Toolbar stb = SToolbar.GetComponent<Sphere_Toolbar>();
                    stb.Sphere = objselected.gameObject;
                    stb.EnableSphereToolbar();
                }
                else if (previous && (previous.name == "to_save_bila" && objselected.name != "to_save_bila"))
                {
                    Sphere_Toolbar stb = SToolbar.GetComponent<Sphere_Toolbar>();
                    stb.DisableSphereToolbar();
                }
              
                if(objselected.name == "to_save_plan_inclinat")
                {
                    PL_Toolbar plt = PLToolbar.GetComponent<PL_Toolbar>();
                    plt.PL = objselected.gameObject;
                    plt.EnablePLTolbar();
                }
                else if(previous && (previous.name == "to_save_plan_inclinat" && objselected.name != "to_save_plan_inclinat"))
                {
                    PL_Toolbar plt = PLToolbar.GetComponent<PL_Toolbar>();
                    plt.DisablePLTolbar();
                }
                previous = raytarget.collider.gameObject;
            }
        }
    }
}
