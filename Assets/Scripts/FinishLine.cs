using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //namespace con clases para manejar el uso de una escena

public class FinishLine : MonoBehaviour
{
    // variables serialized
    [SerializeField] float delayTime = 1.5f; //tiempo de delay para reinciar nivel
    [SerializeField] ParticleSystem finnishEffect; // comunicar las partículas con el inspector

    //variables
    bool hasWon = false; // variable para no repetir varias veces el sfx

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !hasWon)
        {
            hasWon = true; // la hacemos verdadero para no repetir el sfx
            finnishEffect.Play(); //llamamos al efecto de partículas
            GetComponent<AudioSource>().Play(); // reproducimos audio al pasar la meta
            Invoke("ReloadScene", delayTime); //delay de 2 segundos
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0); //cargamos la escena para reinciar el nivel
    }
}
