using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject playerBody;

    public GameObject cameraBody;

    Vector3 tempY = new Vector3(0, 0, 0);

    public void trackPlayer()
    {
        if (cameraBody.transform.position.y != playerBody.transform.position.y + 3)
        {
            tempY = new Vector3(0, playerBody.transform.position.y + 3, -1);
            cameraBody.transform.position = tempY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        trackPlayer();
    }
}
