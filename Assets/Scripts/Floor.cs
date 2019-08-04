using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float xSize = 10.0f;
    public float ySize = 10.0f;
    public float FloorLenth = 1.0f;
    public GameObject floor;
    private Vector3 initialPos;
    private GameObject FloorHolder;
    // Start is called before the first frame update
    void Start()
    {
        CreateFloor();
    }

    void CreateFloor()
    {
        FloorHolder = new GameObject();
        FloorHolder.name = "Floor";
        //initialPos = new Vector3((-xSize / 2) + FloorLenth / 2, 0.0f, (-ySize / 2) + FloorLenth / 2);
        initialPos = new Vector3(-10.0f,0.0f,-20.0f);
        Vector3 myPos = initialPos;
        GameObject tempFloor;

        //*生成X轴方向的墙体
        for (int i = 0; i < ySize; i++)
        {
            for (int j = 0; j <= xSize; j++)
            {
                myPos = new Vector3(initialPos.x + (j * FloorLenth) - FloorLenth / 2, 0.0f, initialPos.z + (i * FloorLenth) - FloorLenth / 2);
                tempFloor = Instantiate(floor, myPos, Quaternion.identity) as GameObject;
                tempFloor.transform.parent = FloorHolder.transform;
            }
        }

        

    }
    // Update is called once per frame
    
}
