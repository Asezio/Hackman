using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class SerializationExample : MonoBehaviour
{
    //public TextAsset EnemyFile;
    public JSONEnemy Enemy;
    public Text EnemyText;
    public void OnEnable()
    {
        var enemyData = File.ReadAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemy)}/EnemyFile.json");
        //File.WriteAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemy)}/EnemyFile2.json",enemyData);
        Enemy = JsonConvert.DeserializeObject<JSONEnemy>(enemyData);
        EnemyText.text = $"{Enemy.Name} : {Enemy.HP}HP";
    }

    public void OnDisable()
    {
        var serializedEnemy = JsonConvert.SerializeObject(Enemy);
        File.WriteAllText($"{Application.dataPath}/StreamingAssets/Data/{typeof(Enemy)}/EnemyFile.json",serializedEnemy);
        Debug.Log(serializedEnemy);
    }
}


