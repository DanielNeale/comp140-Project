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

    void FixedUpdate()
    {
        if (start != new Vector3(0,0,0))
        {
            transform.position = Vector3.Lerp(start, end, time * newSpeed);

            transform.LookAt(otherTrain);

            time += Time.fixedTime;
        }      
    }

    private void OnTriggerEnter(Collider node)
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
    }
}
