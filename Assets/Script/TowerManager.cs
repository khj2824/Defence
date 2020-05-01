using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject tile;
    public GameObject[] Tower;
    public List<Vector2> tilePos;
    public List<GameObject> Towerobj;
    void Start()
    {
        for(int i=0;i<tile.transform.childCount;i++)
        {
            tilePos.Add(tile.transform.GetChild(i).position);
        }

        for(int i=0;i<tilePos.Count;i++)
        {
            int j = Random.Range(0, 6);
            Towerobj.Add(Instantiate(Tower[j], tilePos[i], Quaternion.identity));
            Towerobj[i].name = j.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
