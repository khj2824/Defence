using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float distance = 100f;
    float time=0;
    Vector2 targetpos;
    GameObject AA;
    bool isbool;
    void Start()
    {
        isbool = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            if (Mathf.Min(distance, Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position)) != distance)
            {
                distance = Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position);
                AA = GameObject.FindGameObjectsWithTag("Enemy")[i];
            }
        }
        targetpos = AA.transform.position - transform.position;
        float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        time += Time.deltaTime;
        if (time > 0.2f)
        {
            time = 0;
            distance = 100f;
            gameObject.SetActive(false);
            isbool = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Enemy")
        {
            //Debug.Log("aa");
        }
    }
}
