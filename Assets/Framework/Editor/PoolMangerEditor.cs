using UnityEngine;
using System.Collections;
using UnityEditor;

public class PoolMangerEditor
{
    [MenuItem("Manager/PoolManger")]
    static void CreatPoolList()
    {
        PoolList poolList = ScriptableObject.CreateInstance<PoolList>();
        AssetDatabase.CreateAsset(poolList, "Assets/Framework/Resources/PoolList.asset");
        AssetDatabase.SaveAssets();
    }
}
