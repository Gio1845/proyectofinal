using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileSpeed = 0.3f;

    public int maxXPosition = 102;

    public string damagebleTargetTag = "";
    public float damage = 40f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //la direcion del disparo en el momento que se dispara.
         transform.Translate(new Vector2(0.4f, 0f));
        if (transform.position.x > 102){
            Destroy(gameObject);
    }
    }
    //indentificar el boxcolaider del enemigo y el tag correspondiente para que detecte el impacto de la bala.
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == damagebleTargetTag) {
            Stats enemyStats = other.gameObject.GetComponent<Stats>();

            enemyStats.OnHit(damage);
        }
    }
}

