using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //namespace con clases para manejar el uso de una escena

public class CrashDetector : MonoBehaviour
{
    // variables serialized
    [SerializeField] float delayTime = 1.5f; //tiempo de delay para reinciar nivel
    [SerializeField] ParticleSystem crashEffect; // comunicar las partículas con el inspector
    [SerializeField] AudioClip crashSFX; // variable que nos permite poner sfx en especifico

    // variables
    bool hasCrashed = false; // variable que ayuda a no repetir el sfx
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true; // lo hacemos verdadero para que ya no se vuelva a reproducir
            FindObjectOfType<PlayerController>().DisableControls(); //accedemos al player control y lo desactivamos
            crashEffect.Play(); //llamamos al efecto de partículas
            GetComponent<AudioSource>().PlayOneShot(crashSFX); // le decimos que reproduzca un efecto solo una vez dependiendo de la situacion
            Invoke("ReloadScene", delayTime);  // Invoke("nombreFuncion", delay) delay de 2 segundos
        }
    }
    
    // función que reinicia el nivel cuando el jugador choca
    void ReloadScene()
    {
        SceneManager.LoadScene(0); //recargar el nivel
    }
}
