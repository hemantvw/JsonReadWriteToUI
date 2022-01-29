using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SaveDta : MonoBehaviour
{
    [SerializeField] private PotionData potionData = new PotionData();


    private void Start()
    {
        SaveToJson();
    }

    public void SaveToJson()
    {
        string potion = JsonUtility.ToJson(potionData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/HemantPotionData.json", potion);
        Debug.Log(Application.persistentDataPath);
        


    }
   

}
[System.Serializable]
public class PotionData{

    public string potionName;
    public int Value;
    public List<Effect> effects = new List<Effect>();
}
[System.Serializable]
public class Effect
{

    public string name;
    public int desc;
   
}

