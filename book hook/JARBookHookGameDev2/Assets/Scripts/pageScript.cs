using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class pageScript : MonoBehaviour
{
    public int value;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        playerScore.instance.IncreaseScore(value);
    }
}
