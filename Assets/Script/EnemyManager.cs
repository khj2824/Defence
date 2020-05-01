using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy;
    float time=0;
    void Start()
    {
        StartCoroutine(ememyInit());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ememyInit()
    {
        while(true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
}
