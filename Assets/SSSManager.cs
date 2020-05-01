using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SSSManager : MonoBehaviour
{
    public TowerManager Tower;

    public List<GameObject> select;
    Color[] level = new Color[6];
    static public int count = 0;

    bool ischeck;


    void Start()
    {
        level[0] = Color.white;
        level[1] = Color.yellow;
        level[2] = Color.blue;
        level[3] = Color.red;
        level[4] = Color.green;
        level[5] = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 MousePosition = Input.mousePosition;
            Debug.Log(Camera.main);
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward);
            Debug.DrawRay(MousePosition, transform.forward * 10, Color.white, 0.3f);

            if (hit.collider)
            {
                if (hit.collider.gameObject.GetComponent<SpriteRenderer>().color != level[5])
                {
                    Color color = hit.collider.gameObject.GetComponent<SpriteRenderer>().color;
                    hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.5f);
                    if (select.Count == 0) select.Add(hit.collider.gameObject);
                    else if (select[0] != hit.collider.gameObject)
                    {
                        select.Add(hit.collider.gameObject);
                        ischeck = true;
                    }
                    else if (select[0] == hit.collider.gameObject)
                    {
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1f);
                        select.RemoveAt(0);
                    }
                }
            }
        }

        if (ischeck)
        {
            if (select[0].name == select[1].name && select[0].GetComponent<SpriteRenderer>().color == select[1].GetComponent<SpriteRenderer>().color)
            {
                if (ShiSenShoCheck(select[0], select[1]))
                {
                    Debug.Log("incheck");
                    Upgrade(select[0], select[1]);
                    select.RemoveRange(0, 2);
                    count += 10;
                }
                else
                {
                    for (int i = 0; i < select.Count; i++)
                    {
                        select[i].GetComponent<SpriteRenderer>().color = new Color(select[i].GetComponent<SpriteRenderer>().color.r,
                            select[i].GetComponent<SpriteRenderer>().color.g, select[i].GetComponent<SpriteRenderer>().color.b, 1);
                    }
                    select.RemoveRange(0, 2);
                }
            }

            else
            {
                for (int i = 0; i < select.Count; i++)
                {
                    select[i].GetComponent<SpriteRenderer>().color = new Color(select[i].GetComponent<SpriteRenderer>().color.r,
                            select[i].GetComponent<SpriteRenderer>().color.g, select[i].GetComponent<SpriteRenderer>().color.b, 1);
                }
                select.RemoveRange(0, 2);
            }
            ischeck = false;
        }
    }

    bool ShiSenShoCheck(GameObject first, GameObject second)
    {
        int mask = 1 << 8;

        float f_x = first.transform.position.x;
        float f_y = first.transform.position.y;
        float s_x = second.transform.position.x;
        float s_y = second.transform.position.y;

        if (f_y == s_y)
        {
            Vector2 startpos = new Vector2(f_x, f_y);
            if (Physics2D.RaycastAll(startpos, Vector2.right, s_x - f_x,mask).Length == 2)
            {
                return true;
            }
            else
            {
                for (int i = -10; i <= 10; i++)
                {
                    if (Physics2D.RaycastAll(startpos, new Vector2(0, i), Mathf.Abs(i),mask).Length +
                        Physics2D.RaycastAll(startpos + new Vector2(0, i), new Vector2(s_x - f_x, 0), Mathf.Abs(s_x - f_x),mask).Length +
                        Physics2D.RaycastAll(startpos + new Vector2(s_x - f_x, i), new Vector2(0, -i), Mathf.Abs(i),mask).Length == 2)
                        return true;
                }
            }
        }
        else if (f_x == s_x)
        {
            Vector2 startpos = new Vector2(f_x, f_y);
            if (Physics2D.RaycastAll(startpos, Vector2.up, s_y - f_y,mask).Length == 2)
            {
                return true;
            }
            else
            {
                for (int i = -10; i <= 10; i++)
                {
                    if (Physics2D.RaycastAll(startpos, new Vector2(i, 0), Mathf.Abs(i), mask).Length +
                        Physics2D.RaycastAll(startpos + new Vector2(i, 0), new Vector2(0, s_y - f_y), Mathf.Abs(s_y - f_y), mask).Length +
                        Physics2D.RaycastAll(startpos + new Vector2(i, s_y - f_y), new Vector2(-i, 0), Mathf.Abs(i), mask).Length == 2)
                        return true;
                }
            }
        }
        else
        {
            Vector2 startpos = new Vector2(f_x, f_y);

            if (Physics2D.RaycastAll(startpos, new Vector2(0, s_y - f_y), Mathf.Abs(s_y - f_y),mask).Length +
                Physics2D.RaycastAll(startpos + new Vector2(0, s_y - f_y), new Vector2(s_x - f_x, 0), Mathf.Abs(s_x - f_x),mask).Length == 2)
                return true;

            if (Physics2D.RaycastAll(startpos, new Vector2(s_x - f_x, 0), Mathf.Abs(s_x - f_x),mask).Length +
                Physics2D.RaycastAll(startpos + new Vector2(s_x - f_x, 0), new Vector2(0, s_y - f_y), Mathf.Abs(s_y - f_y),mask).Length == 2)
                return true;

            for (int i = -10; i <= 10; i++)
            {
                if (Physics2D.RaycastAll(startpos, new Vector2(i, 0), Mathf.Abs(i),mask).Length +
                    Physics2D.RaycastAll(startpos + new Vector2(i, 0), new Vector2(0, s_y - f_y), Mathf.Abs(s_y - f_y),mask).Length +
                    Physics2D.RaycastAll(startpos + new Vector2(i, s_y - f_y), new Vector2(-i + (s_x - f_x), 0), Mathf.Abs(-i + (s_x - f_x)),mask).Length == 2)
                    return true;
            }

            for (int i = -10; i <= 10; i++)
            {
                if (Physics2D.RaycastAll(startpos, new Vector2(0, i), Mathf.Abs(i),mask).Length +
                    Physics2D.RaycastAll(startpos + new Vector2(0, i), new Vector2(s_x - f_x, 0), Mathf.Abs(s_x - f_x),mask).Length +
                    Physics2D.RaycastAll(startpos + new Vector2(s_x - f_x, i), new Vector2(0, -i + (s_y - f_y)), Mathf.Abs(-i + (s_y - f_y)),mask).Length == 2)
                    return true;
            }

        }

        return false;
    }

    void Upgrade(GameObject first,GameObject second)
    {
        first.gameObject.SetActive(false);
        SpriteRenderer spr = second.GetComponent<SpriteRenderer>();
        spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1);
        int count = 0;
        while (count < 5)
        {
            if (second.GetComponent<SpriteRenderer>().color == level[count])
            {
                int AA = Random.Range(0, 6);
                second.GetComponent<SpriteRenderer>().sprite = Tower.Tower[AA].GetComponent<SpriteRenderer>().sprite;
                second.name = AA.ToString();
                second.GetComponent<SpriteRenderer>().color = level[count + 1];
                second.GetComponent<Tower>().speed = count + 2;
                break;
            }
            count++;
        }
    }

    public void Towermake()
    {
        List<GameObject> tower = new List<GameObject>();
        bool ismake = false;
        for(int i=0;i<Tower.Towerobj.Count;i++)
        {
            if (Tower.Towerobj[i].activeSelf == false)
            {
                tower.Add(Tower.Towerobj[i]);
                ismake = true;
            }
        }

        if(ismake)
        {
            GameObject aa = tower[Random.Range(0, tower.Count)];
            int i = Random.Range(0, 6);
            aa.SetActive(true);
            aa.GetComponent<SpriteRenderer>().sprite = Tower.Tower[i].GetComponent<SpriteRenderer>().sprite;
            aa.name = i.ToString();
            aa.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }

    public void Towererase()
    {
        if(select.Count==1 && select[0])
        {
            select[0].SetActive(false);
        }
    }
}