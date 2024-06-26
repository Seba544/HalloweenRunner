using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    private Transform _target;

    public float distanceX;
    void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;
        transform.SetParent(_target);
        SetDistanceToPlayer(distanceX);
    }
    void FixedUpdate()
    {
        
    }

    public void SetDistanceToPlayer(float distance)
    {
        // Obtener la posición del objeto a seguir
        Vector3 targetPosition = _target.position;

        // Calcular la nueva posición manteniendo la distancia en el eje X
        Vector3 newPosition = new Vector3(targetPosition.x + distance, transform.position.y, transform.position.z);

        // Actualizar la posición del objeto perseguidor
        transform.position = newPosition;
    }
}
