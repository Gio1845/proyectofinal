using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlniveles : MonoBehaviour
{
  public void Lv1(){
      SceneManager.LoadScene("SceneManagemen");
  }

  public void BackToMenu(){
      SceneManager.LoadScene("Menu");
  }
}
