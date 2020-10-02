using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaFlechaIzq : MonoBehaviour
{
    public float velocidad;
    public int contador = 0;
    public bool adentro = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      transform.position+=transform.right*-velocidad*Time.deltaTime;
      if(contador == 2)
      {
          adentro = true;
      }
      else
      {
          adentro=false;
      }
      if(Input.GetKeyDown(KeyCode.LeftArrow))
      {
          if(adentro)
          {
              GameObject.Find("CasillaJugador").GetComponent<LogicaJugador>().puntaje++;
               GameObject.Find("CasillaJugador").GetComponent<LogicaJugador>().texto.text="Score: "+
                GameObject.Find("CasillaJugador").GetComponent<LogicaJugador>().puntaje.ToString();
            Destroy(gameObject);
                

          }
      }
        
    }
    public void OnTriggerEnter2D(Collider2D collision) 
    {
      if(collision.gameObject.tag=="Player")
      {
          contador++;
      }  
    }
    public void OnTriggerExit2D(Collider2D collision) 
    {
      if(collision.gameObject.tag=="Player")
      {
          contador--;
      }  
    }
}
