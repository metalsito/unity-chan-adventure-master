using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Script copiado de aca https//code.tutsplus.com/tutorials/unity3d-third-person-cameras--mobile-11230 dungeoncrawler camera.

    //Se necesita un objetivo a seguir por la camara.
    public GameObject player;
    //Se necesita un Vector3 para poder hacer el calculo para mantener la distancia entre el player y la camara.
    Vector3 offset;
    
    void Start ()
    {
        //Se calcula el offset para darle un valor la primera vez que se inicie el script.
        offset = transform.position - player.transform.position;
	}

    //Se utiliza el LateUpdate para mejorar el rendimiento.
    private void LateUpdate()
    {
        if (player == null) return;
        //Calculo necesario para que en cada frame que pase la camara siga en la misma posicion.
        Vector3 desiredPosition = player.transform.position + offset;
        transform.position = desiredPosition;
        //LookAt para que la camara siempre mire hacia el player.
        transform.LookAt(player.transform.position);
    }
}
