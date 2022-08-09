using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParent : MonoBehaviour
{
    private List<GameObject> child;

    void Start()
    {
        child = new List<GameObject>();
        for (int i=0; i<transform.childCount; i++)
        {
            child.Add(transform.GetChild(i).gameObject);
        }
    }

    public void SpawnChild()
    {
        foreach (GameObject go in child)
        {
            if (!go.activeInHierarchy) 
            { 
                go.GetComponent<ObjController>().Spawn();
                break;
            }
        }
    }
}
