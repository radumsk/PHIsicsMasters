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
    public GameObject cub;
    public GameObject sfera;
    public GameObject paralelipiped;
    public GameObject plan_inclinat;
    public void Quit_app()
    {
        Application.Quit();

    }
    public void Open_project()
    {
        string patch = EditorUtility.OpenFilePanel("Open Project", "" , "json");
        if(patch=="")
        {
            return;
        }
        string content = File.ReadAllText(patch);
        Project pr = new Project();
        JsonUtility.FromJsonOverwrite(content, pr);
        int index = 0;
        foreach(string name in pr.ids)
        {
            if(name=="to_save_cub")
            {
                GameObject working = Instantiate(cub);
                working.name = "to_save_cub";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index],pr.transforms[index+1],pr.transforms[index+2]);
                working.transform.rotation = new Quaternion(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5],0);
                working.transform.localScale = new Vector3(pr.transforms[index + 6], pr.transforms[index + 7], pr.transforms[index + 8]);
                index += 9;
            }
            if (name == "to_save_bila")
            {
                GameObject working = Instantiate(sfera);
                working.name = "to_save_bila";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = new Quaternion(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5], 0);
                working.transform.localScale = new Vector3(pr.transforms[index + 6], pr.transforms[index + 7], pr.transforms[index + 8]);
                index += 9;
            }
            if (name == "to_save_paralelipiped")
            {
                GameObject working = Instantiate(paralelipiped);
                working.name = "to_save_paralelipiped";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = new Quaternion(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5], 0);
                working.transform.localScale = new Vector3(pr.transforms[index + 6], pr.transforms[index + 7], pr.transforms[index + 8]);
                index += 9;
            }
            if (name == "to_save_plan_inclinat")
            {
                GameObject working = Instantiate(plan_inclinat);
                working.name = "to_save_plan_inclinat";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = new Quaternion(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5], 0);
                working.transform.localScale = new Vector3(pr.transforms[index + 6], pr.transforms[index + 7], pr.transforms[index + 8]);
                index += 9;
            }

        }

        GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_Objects").GetComponent<Canvas>().enabled = true;
    }
    public void Save_project()
    {
        string patch = EditorUtility.SaveFilePanel("Save Project", "", "PHIsicsMasters.json", "json");
        Project de_salvat = new Project();
        de_salvat.transforms = new List<float>();
        de_salvat.ids = new List<string>();

        GameObject[] obj_save = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in obj_save)
        {
            if(obj.GetComponent<Movement>()!=null)
            {
                de_salvat.transforms.Add(obj.transform.position.x);
                de_salvat.transforms.Add(obj.transform.position.y);
                de_salvat.transforms.Add(obj.transform.position.z);
                de_salvat.transforms.Add(obj.transform.rotation.x);
                de_salvat.transforms.Add(obj.transform.rotation.y);
                de_salvat.transforms.Add(obj.transform.rotation.z);
                de_salvat.transforms.Add(obj.transform.localScale.x);
                de_salvat.transforms.Add(obj.transform.localScale.y);
                de_salvat.transforms.Add(obj.transform.localScale.z);
                de_salvat.ids.Add(obj.name);
            }
        }


        string jsondata = JsonUtility.ToJson(de_salvat,true);
        File.WriteAllText(patch, jsondata);
    }
}
