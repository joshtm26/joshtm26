using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject cursorPos;
    public float launchPower = 1f;
    void Awake()
    {
     rb = GetComponent<Rigidbody2D>();
    }

    public void launchPlayer()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 launchDirection = (cursorPos.transform.position - rb.transform.position).normalized;
            rb.AddForce(launchDirection * launchPower, ForceMode2D.Impulse);
        }
    }

    void Update()
    {
        launchPlayer();
    }
}
