using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Menu_UI : MonoBehaviour
{
    public GameObject cub;
    public GameObject sfera;
    public GameObject paralelipiped;
    public GameObject plan_inclinat;
    public string patch;
    public void Quit_app()
    {
        Application.Quit();

    }
    public void Open_project()
    {

        string patch = GameObject.Find("Open").GetComponent<InputField>().text+".json";


        if (patch=="")
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
                working.transform.rotation = pr.rotations[index%6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_bila")
            {
                GameObject working = Instantiate(sfera);
                working.name = "to_save_bila";
                working.tag = "bila";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_paralelipiped")
            {
                GameObject working = Instantiate(paralelipiped);
                working.name = "to_save_paralelipiped";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_plan_inclinat")
            {
                GameObject working = Instantiate(plan_inclinat);
                working.name = "to_save_plan_inclinat";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }

        }
        GameObject.Find("Save").GetComponent<Menu_UI>().patch = patch;
        GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_Objects").GetComponent<Canvas>().enabled = true;
    }
    public void Create_New_Project(string File_Name)
    {

        string patch = File_Name;
        if (patch == "")
        {
            return;
        }
        string content = File.ReadAllText(patch);
        Project pr = new Project();
        JsonUtility.FromJsonOverwrite(content, pr);
        int index = 0;
        foreach (string name in pr.ids)
        {
            if (name == "to_save_cub")
            {
                GameObject working = Instantiate(cub);
                working.name = "to_save_cub";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_bila")
            {
                GameObject working = Instantiate(sfera);
                working.name = "to_save_bila";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_paralelipiped")
            {
                GameObject working = Instantiate(paralelipiped);
                working.name = "to_save_paralelipiped";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }
            if (name == "to_save_plan_inclinat")
            {
                GameObject working = Instantiate(plan_inclinat);
                working.name = "to_save_plan_inclinat";
                working.AddComponent<Movement>();
                working.transform.position = new Vector3(pr.transforms[index], pr.transforms[index + 1], pr.transforms[index + 2]);
                working.transform.rotation = pr.rotations[index % 6];
                working.transform.localScale = new Vector3(pr.transforms[index + 3], pr.transforms[index + 4], pr.transforms[index + 5]);
                index += 6;
            }

        }

        GameObject.Find("Canvas_Menu").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Canvas_Objects").GetComponent<Canvas>().enabled = true;
    }
    public void Save_project()
    {
        string patch = GameObject.Find("Create").GetComponent<InputField>().text+".json";
        Project de_salvat = new Project();
        de_salvat.transforms = new List<float>();
        de_salvat.ids = new List<string>();
        de_salvat.rotations = new List<Quaternion>();
        GameObject[] obj_save = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in obj_save)
        {
            if(obj.GetComponent<Movement>()!=null)
            {
                de_salvat.transforms.Add(obj.transform.position.x);
                de_salvat.transforms.Add(obj.transform.position.y);
                de_salvat.transforms.Add(obj.transform.position.z);
                
                de_salvat.rotations.Add(obj.transform.localRotation);
                de_salvat.transforms.Add(obj.transform.localScale.x);
                de_salvat.transforms.Add(obj.transform.localScale.y);
                de_salvat.transforms.Add(obj.transform.localScale.z);
                de_salvat.ids.Add(obj.name);
                
            }
        }
        if(this.patch.Length>0)
        {
            string jsondata = JsonUtility.ToJson(de_salvat,true);
            File.WriteAllText(this.patch, jsondata);
        }
        else
        {
            string jsondata = JsonUtility.ToJson(de_salvat, true);
            File.WriteAllText(patch, jsondata);
        }
        
        
        
    }
}
