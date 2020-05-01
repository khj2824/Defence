using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject[] Bullet;
    public int speed = 1;

    GameObject AAA;
    BulletManager BulletManager;
    float distance;
    float time = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        AAA = GameObject.Find("Bullet");
        BulletManager = GameObject.Find("Bullet").GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            if (i == 0)
            {
                distance = Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position);
            }
            else
            {
                distance = Mathf.Min(distance, Vector2.Distance(transform.position, GameObject.FindGameObjectsWithTag("Enemy")[i].transform.position));
            }
        }
        if (distance < 2.5f && time > 1/(float)speed)
        {
            time = 0;
            int count = int.Parse(transform.name);
            GameObject bullet;
            //if (count == 4 && transform.childCount==1)
            //{
            //    transform.GetChild(0).gameObject.SetActive(true);
            //}
            //else
            //{
            //    bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
            //    if (count == 4)
            //        bullet.transform.SetParent(transform);
            //    else bullet.transform.SetParent(AAA.transform);
            //}

            switch(count)
            {
                case 0:
                    if(BulletManager.UsedBullet_1.Count==0)
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.name = "0";
                        bullet.transform.SetParent(AAA.transform);
                        BulletManager.Bullet_1.Add(bullet);
                    }
                    else
                    {
                        bullet = BulletManager.UsedBullet_1[0];
                        BulletManager.Bullet_1.Add(bullet);
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        BulletManager.UsedBullet_1.Remove(bullet);
                    }
                    break;
                case 1:
                    if (BulletManager.UsedBullet_2.Count == 0)
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.name = "1";
                        bullet.transform.SetParent(AAA.transform);
                        BulletManager.Bullet_2.Add(bullet);
                    }
                    else
                    {
                        bullet = BulletManager.UsedBullet_2[0];
                        BulletManager.Bullet_2.Add(bullet);
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        BulletManager.UsedBullet_2.Remove(bullet);
                    }
                    break;
                case 2:
                    if (BulletManager.UsedBullet_3.Count == 0)
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.name = "2";
                        bullet.transform.SetParent(AAA.transform);
                        BulletManager.Bullet_3.Add(bullet);
                    }
                    else
                    {
                        bullet = BulletManager.UsedBullet_3[0];
                        BulletManager.Bullet_3.Add(bullet);
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        BulletManager.UsedBullet_3.Remove(bullet);
                    }
                    break;
                case 3:
                    if (BulletManager.UsedBullet_4.Count == 0)
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.name = "3";
                        bullet.transform.SetParent(AAA.transform);
                        BulletManager.Bullet_4.Add(bullet);
                    }
                    else
                    {
                        bullet = BulletManager.UsedBullet_4[0];
                        BulletManager.Bullet_4.Add(bullet);
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        BulletManager.UsedBullet_4.Remove(bullet);
                    }
                    break;
                case 4:
                    if (transform.childCount == 1)
                    {
                        transform.GetChild(0).gameObject.SetActive(true);
                    }
                    else
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.transform.SetParent(transform);
                    }
                    break;
                case 5:
                    if (BulletManager.UsedBullet_5.Count == 0)
                    {
                        bullet = Instantiate(Bullet[count], transform.position, Quaternion.identity);
                        bullet.name = "4";
                        bullet.transform.SetParent(AAA.transform);
                        BulletManager.Bullet_5.Add(bullet);
                    }
                    else
                    {
                        bullet = BulletManager.UsedBullet_5[0];
                        BulletManager.Bullet_5.Add(bullet);
                        bullet.SetActive(true);
                        bullet.transform.position = transform.position;
                        BulletManager.UsedBullet_5.Remove(bullet);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
