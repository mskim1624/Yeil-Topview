using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{
    public static SaveDataList arrangedataList;
    // Start is called before the first frame update
    void Start()
    {
        arrangedataList = new SaveDataList();
        arrangedataList.saveDatas = new SaveData[] { };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
