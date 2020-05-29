﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fireDelay = 1f;

    public int onFireProjectileCount = 3;

    private int projectilesFired = 0;

    public GameObject projectile;

    private float timeSinceLastFire = 0f;

    private float maxPositionX = 1f;
    private float minPositionX = 0f;

    private bool movingRight = true;

    public float movementSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        // tamaño pantalla
        // Screen.width

        // tamaño de la nave
        //     SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //    float spriteWidth = sr.sprite.rect.width;

        //    maxPositionX = Screen.width - (spriteWidth / 2);

        //    minPositionX = 0 + (spriteWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        timeSinceLastFire += Time.deltaTime;

        if (movingRight)
        {
            //El enemigo se  movera a la Derecha
            transform.Translate(new Vector2(movementSpeed, 0f));

            if (pos.x >= maxPositionX)
            {
                //El enemigo se  movera a la izquierda
                movingRight = false;
            }
        }
        else
        {
            // El enemigo se  movera a la izquieda 
            transform.Translate(new Vector2(-movementSpeed, 0f));

            if (pos.x <= minPositionX)
            {
                //El enemigo se  movera a la derecha
                movingRight = true;
            }
        }
        ///el enemigo disparara solo cada cierto tiempo y le hara daño al jugador cuando lo vea 
        if (timeSinceLastFire >= fireDelay && projectilesFired < onFireProjectileCount)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            projectile.GetComponent<Projectile>().damagebleTargetTag = "Player";

            projectilesFired++;

            //el tiempo que tarda para volver a disparar 
            if(projectilesFired >= onFireProjectileCount)
            {
                timeSinceLastFire = 0f;
                projectilesFired = 0;
            }
        }
    }
}

