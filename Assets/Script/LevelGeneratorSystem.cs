using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorSystem : MonoBehaviour
{
    public BaseGridObject[] BaseGridObjectsPrefabs;

    public List<string> levelFileNames = new List<string>();
    [SerializeField] private string level;
    
    public static int[,] Grid = new int[,]
    {
        { 1,1,1,1,1,1,1,1,1,1},
        { 1,0,1,0,0,0,0,3,0,1},
        { 1,0,2,0,0,1,0,0,0,1},
        { 1,1,0,0,0,1,1,0,0,1},
        { 1,0,0,1,0,1,0,0,1,1},
        { 1,0,0,1,0,3,0,0,0,1},
        { 1,1,1,1,1,1,1,1,1,1}
    };

    void Awake()
    {
        level = levelFileNames[Random.Range(0, levelFileNames.Count - 1)];
        Grid = JSONGeneric.Load<Level>(level).Grid;

        for(int i = 0 ; i < Grid.GetLength(0); i++)
        {
            for(int j = 0; j < Grid.GetLength(1); j ++)
            {
                var objectType = Grid[i, j];
                var gridObjectPrefab = BaseGridObjectsPrefabs[objectType];
                var gridObjectClone = Instantiate(gridObjectPrefab);
                gridObjectClone.GridPosition = new IntVector2(j, -i);
                gridObjectClone.transform.position = new Vector3(gridObjectClone.GridPosition.x, gridObjectClone.GridPosition.y, 0f);
                //Instantiate(BaseGridObjectsPrefabs[Grid[i,j]], new Vector3(j , -i, 0), Quaternion.identity);
            }
        }
        
    }
}


public class Level
{
    public int[,] Grid;
}