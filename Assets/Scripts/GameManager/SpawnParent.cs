using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParent : MonoBehaviour
{
    [SerializeField] private GameObject childPrefabs;
    [SerializeField] private int poolSize;
    private List<GameObject> child;

    void Start()
    {
        child = new List<GameObject>();

        for (int i=0; i<poolSize; i++)
        {
            InstantiatePoolObj();
        }
    }

    //Menspawn Object Dari Pool
    public void SpawnChild()
    {
        foreach (GameObject go in child)
        {
            if (!go.activeInHierarchy) 
            { 
                go.GetComponent<ObjController>().Spawn();
                return;
            }
        }

        //Jika Seluruh Obj Di Pool Aktif
        InstantiatePoolObj();
        child[child.Count - 1].SetActive(true);
    }

    private void InstantiatePoolObj()
    {
        GameObject obj = Instantiate(childPrefabs, transform);
        obj.GetComponent<ObjController>().Spawn();
        child.Add(obj);
        obj.SetActive(false);
    }
}
