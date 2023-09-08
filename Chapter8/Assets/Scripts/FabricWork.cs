using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FabricWork : MonoBehaviour
{
    [SerializeField] private GameObject[] robots = new GameObject[5];
    [SerializeField] private GameObject Box;

    private Vector3[] startPositions = new Vector3[5];
    private Vector3[] finishPositions = new Vector3[5];
    //private bool[] statuses = new bool[5];
    void Start()
    {
        for (int i = 0; i < robots.Length; i++)
        {
            startPositions[i] = robots[i].GetComponent<Move>().point1.position;
            finishPositions[i] = robots[i].GetComponent<Move>().point2.position;
            robots[i + 1].transform.LookAt(robots[i].transform);
        }
        Instantiate(Box, new Vector3(0f, 0f, -6.08f), Quaternion.identity, robots[0].transform);
    }

    void Update()
    {
        if (robots[0].transform.childCount == 0 && robots[0].transform.position == startPositions[0])
        {
            robots[0].transform.LookAt(robots[1].transform.position);
            Instantiate(Box, new Vector3(0f, 0f, -6.08f), Quaternion.identity, robots[0].transform);
        }

        for (int i = 0; i < robots.Length - 1; i++)
        {
            if ((robots[i].transform.position == finishPositions[i] && robots[i].transform.GetChild(0) != null) &&
                robots[i + 1].transform.position == startPositions[i + 1])
            {
                robots[i].transform.GetChild(0).SetParent(robots[i + 1].transform);
            }

            if (robots[robots.Length - 1].transform.position == finishPositions[finishPositions.Length - 1]
                && robots[robots.Length - 1].transform.GetChild(0) != null)
            {
                Destroy(robots[robots.Length - 1].transform.GetChild(0).gameObject);
            }
        }
    }
}
