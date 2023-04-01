using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem dustParticles; //variable para acceder a las part�culas
    
    //cuando el jugador est� en el suelo salen part�culas de nieve continuamente.
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground") 
        {
            dustParticles.Play();
        }
    }

    // cuando dejamos de colisionar con el suelo, paramos las part�culas del suelo
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            dustParticles.Stop();
        }
    }
}