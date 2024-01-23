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
        // Crear una nueva part�cula en la posici�n de la c�mara
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Obtener el componente Rigidbody de la part�cula
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Disparar la part�cula en la direcci�n que la c�mara est� apuntando
        rb.velocity = transform.forward * bulletSpeed;
    }
}
