using System;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 资源池
/// </summary>
[Serializable]
public class GameObjectPool
{
    [SerializeField] public string poolName;
    [SerializeField] private GameObject prefab;
    [SerializeField] private int maxAmount;

    [NonSerialized] private List<GameObject> goList=new List<GameObject>();

    //获取对象
    public GameObject GetInstance()
    {
        foreach (var go in goList)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }
        }

        if (goList.Count>=maxAmount)
        {
            GameObject.Destroy(goList[0]); 
            goList.RemoveAt(0);
        }

        GameObject temp=GameObject.Instantiate(prefab);
        goList.Add(temp);
        return temp;
    }
}
