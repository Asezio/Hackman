using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class JSONGeneric
{
    //private static JSONGeneric jsonGeneric;
    //public static JSONGeneric Instance => jsonGeneric ?? (jsonGeneric = new JSONGeneric());
    
    //Save method, for saving a type to a file with a name provided by the person saving 

    public Text text;
    public static T Save<T>(T appData, string filename)
    {
        //Get path and folder based on the type,automatically
        //For example, if we save an Enemy type object,it will be in a folder called "Enemys"
        var path = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}/";

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        if (!File.Exists($"{path}{filename}"))
        {
            var fileStrean = File.Create($"{path}{filename}.json");
            fileStrean.Close();
        }
        
        File.WriteAllText($"{path}/{filename}.json",JsonConvert.SerializeObject(appData));
        return appData;
    }
    
    
    //Load method, for loading objects of any type, given a a filename
    public static T Load<T>( string fileName) where T : new()
    {
        var path = $"{Application.dataPath}/StreamingAssets/Data/{typeof(T)}/";
        
        if (File.Exists($"{path}{fileName}"))
        {
            var appData = JsonConvert.DeserializeObject<T>(File.ReadAllText($"{path}{fileName}.json"));
            return appData;
        }

        return Save( new T(), fileName);
    }
    
    
}
