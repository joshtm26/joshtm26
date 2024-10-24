using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class grappleHook : MonoBehaviour
{
    public LineRenderer lineRend;
    public GameObject cursorPos;
    public GameObject playerBody;
    public bool isColliding;
    private float distance;
    private float timer = 1f;
    public float hookRate = 1f;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }

    public void generateLine()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lineRend.enabled = true;
            lineRend.positionCount = 2;
            lineRend.SetPosition(0, playerBody.transform.position);
            lineRend.SetPosition(1, cursorPos.transform.position);
            distance = Mathf.Abs((cursorPos.transform.position.x - playerBody.transform.position.x) + (cursorPos.transform.position.y - playerBody.transform.position.y));
            timer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if( timer >= hookRate)
        {
            generateLine();
        }
    }
}
