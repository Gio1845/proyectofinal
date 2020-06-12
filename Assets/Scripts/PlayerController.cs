using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;
    public float fireDelay = 1f;

    private float timeSinceLastFire = 0f;
    public float playerSpeed = 0.1f;
    public GameObject Reset;
    // Start is called before the first frame update
    void Start()
    {
        Reset.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento que tendra el jugador que es movimiento en vertical en un solo eje.
        float VerticalMovement = Input.GetAxis("Vertical");
        if (VerticalMovement != 0)
        {
            Vector2 newPosition = new Vector2(0f, VerticalMovement * 0.1f);
            transform.Translate(newPosition);
        }
        //Agregar tiempo del ultimo frame al tiempo transcurrido
        timeSinceLastFire += Time.deltaTime;

        //Solamente se puede disparar si ya paso el tiempo definido
        if (timeSinceLastFire >= fireDelay)
        {
            //El jugador despues de que paso el tiempo dispara
            if (Input.GetButton("Fire1"))
            {
                Debug.Log("Pew");

                Instantiate( projectile, transform.position + new Vector3(1f, 0f, 0f) * 1f, transform.rotation);
                timeSinceLastFire = 0f;
                projectile.GetComponent<Projectile>().damagebleTargetTag = "Enemy";

                timeSinceLastFire = 0f;

            }
        }
            Reset.gameObject.SetActive(true);
    }
}

