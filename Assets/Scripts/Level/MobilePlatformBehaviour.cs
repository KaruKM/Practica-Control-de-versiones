using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatformBehaviour : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float speed, offset;
    [SerializeField] float waitTime, timer;
    int currentTarget;
    
    private void Start()
    {
        currentTarget = 0;
        timer = 0;
    }
    private void Update()
    {

        //Acercar al positions[currentTarget]

        Vector3 directon;
        Vector3 destiny = positions[currentTarget].position;
        Vector3 currentPosition = transform.position;

        //Posicion de destino menos posicion actual
        directon = destiny - currentPosition;
        directon.Normalize();

        Vector3 newPosition;
        newPosition = currentPosition + (directon * speed * Time.deltaTime);
        transform.position = newPosition;

        float distance = Vector3.Distance(newPosition, destiny);
        if (distance < offset)
        {
            //Ha llegado al destino
            //print("Ha llegado al destino");
            timer += Time.deltaTime;
            if (timer >= waitTime)
            {
                currentTarget++;
                if(currentTarget >= positions.Length)
                {
                    currentTarget = 0;
                }
                timer = 0;
            }
        }
    }
}
