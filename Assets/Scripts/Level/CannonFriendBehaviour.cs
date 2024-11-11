using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFriendBehaviour : MonoBehaviour
{
    [SerializeField] Transform shootingPoint;
    [SerializeField] float shootingDelay;
    [SerializeField] Vector3 force;

    Rigidbody target;

    void SetInShootingPoint(Rigidbody target)
    {
        target.transform.position = shootingPoint.position;
    }
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(shootingDelay);
        Shoot();
    }
    void Shoot()
    {
        target.isKinematic = false;

        target.AddForce(force);
        target = null;

    }
    void SetTarget(Rigidbody newTarget)
    {
        target = newTarget;
        target.isKinematic = true;

        SetInShootingPoint(target);
        StartCoroutine(ShootDelay());

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && target == null)
        {
            SetTarget(collision.gameObject.GetComponent<Rigidbody>());
        }
    }
}
