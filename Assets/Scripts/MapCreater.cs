using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreater : MonoBehaviour
{
    public static MapCreater Instance;

    public GameObject wallObj;
    public int blockSize = 2;
    private int[,] map = new int[,]
    {
        {1,1,1,1,1,1,1,1,1,1,1,1, },
        {1,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,1,0,0,0,0,0,0,0,0,1, },
        {1,0,1,0,1,1,0,0,0,0,0,1, },
        {1,0,1,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,1, },
        {1,0,0,0,0,0,0,0,0,0,0,1, },
        {1,1,1,1,1,1,1,1,1,1,1,1, },
    };
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for(int y =  0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] != 0)
                    Instantiate(wallObj, new Vector3(x * blockSize,blockSize,-y * blockSize),Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckMap(int x , int y)
    {
        x /= blockSize;
        y = y / blockSize * -1;
        if (map[y,x] == 0)
        {
            return true;
        }
        return false;
    }
}
