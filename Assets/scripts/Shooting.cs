using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Crear una nueva partícula en la posición de la cámara
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Obtener el componente Rigidbody de la partícula
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Disparar la partícula en la dirección que la cámara está apuntando
        rb.velocity = transform.forward * bulletSpeed;
    }
}
