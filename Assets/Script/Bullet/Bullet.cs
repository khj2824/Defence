using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletManager BulletManager;
    float distance = 100f;
    Vector2 targetpos;
    GameObject AA;
    bool isbool;
    void Start()
    {
        isbool = true;
        BulletManager = GameObject.Find("Bullet").GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isbool)
        {
            isbool = false;
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
            {
                if (Mathf.Min(distance, Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position)) != distance)
                {
                    distance = Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position);
                    AA = GameObject.FindGameObjectsWithTag("Enemy")[i];
                }
            }
        }

        if(AA)
            targetpos = AA.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetpos, 0.15f);

        if(Vector2.Distance(transform.position,targetpos)<0.2f)
        {
            isbool = true;
            distance = 100f;
            switch (gameObject.name)
            {
                case "0":
                    transform.position = new Vector3(1000, 1000);
                    gameObject.SetActive(false);
                    BulletManager.Bullet_1.Remove(gameObject);
                    BulletManager.UsedBullet_1.Add(gameObject);
                    break;
                case "1":
                    transform.position = new Vector3(1000, 1000);
                    gameObject.SetActive(false);
                    BulletManager.Bullet_2.Remove(gameObject);
                    BulletManager.UsedBullet_2.Add(gameObject);
                    break;
                case "2":
                    transform.position = new Vector3(1000, 1000);
                    gameObject.SetActive(false);
                    BulletManager.Bullet_3.Remove(gameObject);
                    BulletManager.UsedBullet_3.Add(gameObject);
                    break;
                case "3":
                    transform.position = new Vector3(1000, 1000);
                    gameObject.SetActive(false);
                    BulletManager.Bullet_4.Remove(gameObject);
                    BulletManager.UsedBullet_4.Add(gameObject);
                    break;
                case "4":
                    transform.position = new Vector3(1000, 1000);
                    gameObject.SetActive(false);
                    BulletManager.Bullet_5.Remove(gameObject);
                    BulletManager.UsedBullet_5.Add(gameObject);
                    break;
            }
        }
    }
}
