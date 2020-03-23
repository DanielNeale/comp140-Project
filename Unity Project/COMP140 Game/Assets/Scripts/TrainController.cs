using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0;
    //[SerializeField]
    //private Transform otherTrain = null;
    [SerializeField]
    Transform startPos = null;

    private Vector3 start;
    private Vector3 end;
    private float newSpeed;
    private float time;

    private Transform node;

    void Start()
    {
        transform.position = startPos.position;
    }

    void Update()
    {
        if (node != null)
        {
            int nodeX = Mathf.RoundToInt(node.transform.position.x * 5);
            int nodeZ = Mathf.RoundToInt(node.transform.position.z * 5);
            int trainX = Mathf.RoundToInt(transform.position.x * 5);
            int trainZ = Mathf.RoundToInt(transform.position.z * 5);

            if (nodeX == trainX && nodeZ == trainZ)
            {
                Transform rail = node.transform.parent;

                for (int i = 0; i < rail.childCount; i++)
                {
                    if (rail.GetChild(i) != node.transform)
                    {
                        start = new Vector3 (node.transform.position.x, transform.position.y, node.transform.position.z);
                        end = new Vector3 (rail.GetChild(i).position.x, transform.position.y, rail.GetChild(i).position.z);
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

            //transform.LookAt(otherTrain);

            time += Time.fixedTime;
        }

        else
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        node = collision.transform;                      
    }
}
