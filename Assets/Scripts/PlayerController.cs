using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // variables serialized
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float brakeSpeed = 5f;

    // variables de clase
    SurfaceEffector2D surfaceEffector2D; //variable para modificar las propiedades del movimiento en superficie
    Rigidbody2D rb2d; // variable para modificar el movimiento del jugador.
    bool canMove = true; // variable que comprueba que el jugador ha chocado

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //obtenemos el rigidbody del jugador (la patineta)
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); //obtenemos las propiedades de la superficie
    }

    // función que permite que el jugador frene o acelere con las flechas de abajo y arriba.
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = brakeSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    // lo hacemos publico para que otras clases y scripts puedan accederlo
    public void DisableControls()
    {
        canMove = false;
    }

    // función que acepta inputs de las flechas para rotar al jugador a la derecha o izquierda
    void RotatePlayer() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove) // mientras sea true el jugador podra moverse
        {
            RotatePlayer();
            RespondToBoost();
        }
    }
}
