using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class grappleScript : MonoBehaviour
{
    public GameObject cursorPos;
    public GameObject playerBody;
    LineRenderer lineRend;
    Rigidbody2D rb;
    public float launchForce = 500f;
    public float hookRate = 1;
    public bool grapple = false;
    public playerMovement movementScript;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRend = GetComponent<LineRenderer>();
        movementScript = GetComponent<playerMovement>();
    }

    Vector3 LocationHit()
    {
        RaycastHit2D locHit = Physics2D.Raycast(playerBody.transform.position + new Vector3(0, 1f, 0), (cursorPos.transform.position - playerBody.transform.position).normalized, 100f); 
        Vector3 locHitPosition = locHit.point;
        if (locHit.collider != null)
        {
            return locHitPosition;
        }
        return Vector3.zero;
    }

    void drawLine()
    {

            lineRend.enabled = true;
            lineRend.positionCount = 2;
            lineRend.SetPosition(0, playerBody.transform.position);
            lineRend.SetPosition(1, LocationHit()); 
    }

    void launchPlayer()
    {
        
        rb.AddForce((LocationHit() - playerBody.transform.position).normalized * launchForce * Time.deltaTime);
    }

    void Update()
    {
        
        if(grapple == true)
        {
            launchPlayer(); 
            drawLine();
        }
        if (Input.GetMouseButtonUp(0) && grapple == true)
        {
            grapple = false;
            movementScript.enabled = true;
        }
        if (Input.GetMouseButtonDown(0) && grapple == false)
        {
            if(LocationHit() != Vector3.zero)
            {
                grapple = true;
                movementScript.enabled = false;
            }
        } 
    }
}
