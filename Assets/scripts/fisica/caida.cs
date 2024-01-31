using UnityEngine;

public class caida : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Destroy(other.gameObject);


        }
    }
}