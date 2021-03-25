using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Menu_UI : MonoBehaviour
{
    public void Quit_app()
    {
        Application.Quit();

    }
    public void Open_project()
    {
        string patch = EditorUtility.OpenFilePanel("Open Project", "" , "json");
        string content = File.ReadAllText(patch);
        Project pr = new Project();
        JsonUtility.FromJsonOverwrite(content, pr);
        Debug.Log("Ceva");
        GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_Objects").GetComponent<Canvas>().enabled = true;
    }
    public void Save_project()
    {
        string patch = EditorUtility.SaveFolderPanel("Save Project", "", "PHIsicsMasters.json");
        Project de_salvat = new Project();
        ///de terminat
 
        string jsondata = JsonUtility.ToJson(de_salvat,true);
        File.WriteAllText(patch + "/Project.json", jsondata);
    }
}
