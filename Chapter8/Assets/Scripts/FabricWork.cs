using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FabricWork : MonoBehaviour
{
    public GameObject [] robots = new GameObject[5];
    public GameObject Box;
    void Start()
    {
        for (int i = 1; i < robots.Length; i++)
        {
            robots[i].GetComponent<Move>().Go = false;
            robots[i].transform.LookAt(robots[i - 1].transform);
        }
        Instantiate(Box, new Vector3(0f,0f,-6.08f),Quaternion.identity, robots[0].transform);
        robots[0].GetComponent<Move>().Go = true;
    }

    void Update()
    {
        if ((robots[0].transform.childCount == 0) && robots[0].transform.position == robots[0].GetComponent<Move>().point1.position)
        {
            robots[0].transform.LookAt(robots[1].transform.position);
            Instantiate(Box, new Vector3(0f, 0f, -6.08f), Quaternion.identity, robots[0].transform);
        }

        for (int i = 0; i < robots.Length-1; i++)
        {
            if ((robots[i].transform.position == robots[i].GetComponent<Move>().point2.position) && (robots[i].transform.GetChild(0)!=null))
            {
                robots[i].transform.GetChild(0).SetParent(robots[i+1].transform);
                robots[i].transform.LookAt(robots[i].GetComponent<Move>().point1);
                robots[i + 1].GetComponent<Move>().Go = true;
            }
            else if ((robots[robots.Length - 1].transform.position == robots[robots.Length - 1].GetComponent<Move>().point2.position)
                && ((robots[robots.Length - 1].transform.GetChild(0)!=null)))
            {
                Destroy(robots[robots.Length - 1].transform.GetChild(0).gameObject);
            }
        }
    }
}
