using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    [SerializeField]
    private Transform otherTrain = null;

    private Vector3 start;
    private Vector3 end;
    private float newSpeed;
    private float time;

    private Transform node;

    void Update()
    {
        if (node != null)
        {
            int nodeX = Mathf.RoundToInt(node.transform.position.x * 10);
            int nodeZ = Mathf.RoundToInt(node.transform.position.z * 10);
            int trainX = Mathf.RoundToInt(transform.position.x * 10);
            int trainZ = Mathf.RoundToInt(transform.position.z * 10);

            Debug.Log((nodeX, trainX, nodeZ, trainZ));

            if (nodeX == trainX && nodeZ == trainZ)
            {
                Transform rail = node.transform.parent;

                for (int i = 0; i < rail.childCount; i++)
                {
                    if (rail.GetChild(i) != node.transform)
                    {
                        start = node.transform.position;
                        end = rail.GetChild(i).position;
                    }
                }

                time = 0;
                newSpeed = speed / Vector3.Distance(start, end);
                node = null;
            }
        }
    }

    void FixedUpdate()
    {
        if (start != new Vector3(0,0,0))
        {
            transform.position = Vector3.Lerp(start, end, time * newSpeed);

            transform.LookAt(otherTrain);

            time += Time.fixedTime;
        }      
    }

    private void OnTriggerEnter(Collider collision)
    {
        node = collision.transform;                      
    }
}
