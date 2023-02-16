using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public int arrangeID = 0;
    public string objTag = "";
}

[Serializable]
public class SaveDataList
{
    public SaveData[] saveDatas;
}
