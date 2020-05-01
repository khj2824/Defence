using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> node;
    public TowerManager tower;
    public UIUXManager UIUX;
    public List<float> distance = new List<float>();
    int count = 1;

    void Start()
    {
        tower = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        UIUX = GameObject.Find("UIUXManager").GetComponent<UIUXManager>();
        Transform nodeparent = GameObject.Find("Node").transform;
        for(int i=0;i<nodeparent.childCount;i++)
        {
            node.Add(nodeparent.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 13) Destroy(gameObject);
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, node[count].position, Time.deltaTime * 3f);
            if (transform.position == node[count].position)
                count++;
        }
    }
}
