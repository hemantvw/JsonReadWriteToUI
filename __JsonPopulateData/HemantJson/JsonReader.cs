using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonReader : MonoBehaviour
{
     string jsonContent;
    public TextAsset JsonFile;

    public Text PotionName;
    public Text PotionValue;
    //public Text EffectName;
  //  public Text EffectDesc;

    public Transform ListParentObject;
    public GameObject ListPrefab;

    // Start is called before the first frame update
    void Start()
    {
        jsonContent = JsonFile.ToString();
      //  ProcessJsonData(jsonContent);
        ProcessJsonData2();

        //if there is actual URL
        // StartCoroutine(getData());
    }
    //if there is actual URL
  /*  IEnumerator getData()
    {
        Debug.Log("Processing Data Please Wait");
        WWW _www = new WWW(jsonContent);
        yield return _www;
        if (_www.error == null)
        {
            ProcessJsonData(_www.text);
        }
        else
        {
            Debug.Log("Oops Something went wrong ");

        }

    }*/
    public void ProcessJsonData(string _jsonContent)
    {
        PotionData pdata = JsonUtility.FromJson<PotionData>(_jsonContent);
        Debug.Log(pdata.potionName);
        Debug.Log(pdata.effects);
        foreach (Effect eff in pdata.effects)
        {
            Debug.Log(eff.name);
            Debug.Log(eff.desc);
        }

    }
    public void ProcessJsonData2()
    {
        string js = File.ReadAllText(Application.persistentDataPath + "/HemantPotionData.json");
        PotionData pdata = JsonUtility.FromJson<PotionData>(js);
        Debug.Log(pdata.potionName);
        PotionName.text = pdata.potionName;
        PotionValue.text = pdata.Value.ToString();
        Debug.Log(pdata.effects);
        foreach (Effect eff in pdata.effects)
        {
            GameObject go = Instantiate(ListPrefab);
            go.transform.parent = ListParentObject;
            Debug.Log(eff.name);
            Debug.Log(eff.desc);
            go.transform.GetChild(0).GetComponent<Text>().text = eff.name;
            go.transform.GetChild(1).GetComponent<Text>().text = eff.desc.ToString();
      //     EffectName.text = eff.name;
     //       EffectDesc.text = eff.desc.ToString();
        }

    }
}
