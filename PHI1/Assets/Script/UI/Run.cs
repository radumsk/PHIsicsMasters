using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Run : MonoBehaviour
{
    public Text text;
    private bool running;
    public Run()
    {
        running = false;
    }
   public void Runn()
   {
        if (!running)
        {
            GameObject.Find("Save").GetComponent<Menu_UI>().Save_project();
            GameObject[] gameobject = GameObject.FindGameObjectsWithTag("bila");
            foreach (GameObject obj in gameobject)
            {
                //obj.AddComponent<Rigidbody>();
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                rb.isKinematic = false;
            }
            running = true;
            text.text = "stop";
        }
        else
        {
            MeshRenderer[] gameObjects = GameObject.FindObjectsOfType<MeshRenderer>();
        
            foreach(MeshRenderer mesh in gameObjects)
            {
                Destroy(mesh.gameObject);

            }
            GameObject.Find("Canvas_Menu").GetComponent<Menu_UI>().Open_project();
            running = false;
            text.text = "run";
        }
        
   }
    public void Slowdown(float value)
    {
        Time.timeScale = value;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
