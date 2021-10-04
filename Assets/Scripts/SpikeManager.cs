using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    [SerializeField] private SpikeMovement _spike;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _spike.StartCoroutine("SpikeMove");
        }
    }
}
