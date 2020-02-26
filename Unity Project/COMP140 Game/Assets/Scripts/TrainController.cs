using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private int speed = 0;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider node)
    {
        Transform rail = node.transform.parent;
        Transform targetNode = null;

        for (int i = 0; i < rail.childCount; i++)
        {
            if (rail.GetChild(i) != node.transform)
            {
                targetNode = rail.GetChild(i);
                Debug.Log(targetNode);
            }
        }

        transform.LookAt(targetNode.position);
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
}
