using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBehaviour : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField]Transform shootingPoint;
    [SerializeField] int burstCount;
    [SerializeField] float shootDelay;
    [SerializeField] float burstDelay;

    private void Start()
    {
        StartCoroutine(ShootSequence());
    }

    void Shoot()
    {
        GameObject instantiatedBullet;

        // Estoy pulsando C, crea una bala
        instantiatedBullet = GameObject.Instantiate(projectile, shootingPoint.position, shootingPoint.rotation);

        instantiatedBullet.GetComponent<ProjectileBehaviour>().ChangeParent(transform);
    }

    IEnumerator ShootSequence()
    {
        //Repetir
        for (; true;)
        { 
            //Repetir hasta acabar ráfaga
            for (int counter = 0; counter < burstCount; counter++)
            { 
                //Disparar
                Shoot();
                //Esperar entre disparos
                yield return new WaitForSeconds(shootDelay);
            }
            //Esperar entre ráfagas
            yield return new WaitForSeconds(burstDelay);
        }
    }
}