using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles; //variable para acceder a las partículas
    
    //cuando el jugador está en el suelo salen partículas de nieve continuamente.
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground") 
        {
            dustParticles.Play();
        }
    }

    // cuando dejamos de colisionar con el suelo, paramos las partículas del suelo
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            dustParticles.Stop();
        }
    }
}