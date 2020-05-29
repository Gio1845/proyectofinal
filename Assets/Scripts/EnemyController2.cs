﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
     public float fireDelay = 1f;

    public int onFireProjectileCount = 3;

    // private int projectilesFired = 0;

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
            // El enemigo se movera a la derecha
            transform.Translate(new Vector2(movementSpeed, 0f));

            if (pos.x >= maxPositionX)
            {
                // El enemigo se movera  a la izquierda
                movingRight = false;
            }
        }
        else
        {
            // el enemigo se movera a la izquierda
            transform.Translate(new Vector2(-movementSpeed, 0f));
            //el enemigo se movera a la derecha
            if (pos.x <= minPositionX)
            {
                movingRight = true;
            }
        }
    }
}
