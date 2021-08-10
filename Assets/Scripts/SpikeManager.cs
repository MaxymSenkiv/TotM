using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] private SpikeMovement Spike;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Spike.StartCoroutine("SpikeMove");
        }
    }
}
