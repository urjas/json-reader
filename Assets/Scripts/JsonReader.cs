using UnityEngine;
using System.Collections;
[System.Serializable]
public class JSONobj
{

    public string full_name;
	public string description;
	public string language;
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.objs;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.objs = array;
        return UnityEngine.JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] objs;
    }
}

//[System.Serializable]
public class JsonReader : MonoBehaviour {

	public string url;
	WWW www;
	
	// Use this for initialization
	IEnumerator Start () {
	print("Start");
	www=new WWW(url);
	yield return www;
	string jsonString=www.text;
	
	jsonString = "{\"objs\":" + jsonString + "}";
	print(jsonString);
	JSONobj[] jsontotext;
	jsontotext = JsonHelper.FromJson<JSONobj>(jsonString);
	for(int i=0;i<jsontotext.Length;i++){
		print(jsontotext[i].full_name + " " +jsontotext[i].description + " " +jsontotext[i].language);
	}
}
	
	// Update is called once per frame
	void Update () {
	
	}

	
}
