using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailController : MonoBehaviour
{
    [SerializeField]
    private Transform[] rails = null;
    
    private bool railOneActive;
    private bool railTwoActive;
    private bool railThreeActive;
    private bool railFourActive;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            railOneActive = !railOneActive;
            transformRail(railOneActive, 0, 1);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            railTwoActive = !railTwoActive;
            transformRail(railTwoActive, 1, -1);
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            railThreeActive = !railThreeActive;
            transformRail(railThreeActive, 2, 1);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            railFourActive = !railFourActive;
            transformRail(railFourActive, 3, -1);
        }
    }

    private void transformRail(bool active, int rail, int direction)
    {
        if (active)
        {
            rails[rail].Rotate(Vector3.up, 15 * direction);
        }

        if (!active)
        {
            rails[rail].Rotate(Vector3.up, -15 * direction);
        }
    }
}
