using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Object_creator : MonoBehaviour, IPointerClickHandler
{
    public GameObject prefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clone=Instantiate(prefab);
        clone.AddComponent<Movement>();
        clone.AddComponent<MeshCollider>();
        clone.AddComponent<Selection>();
    }
    
    
}
