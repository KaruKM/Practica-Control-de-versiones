using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float speed;

    private void OnTriggerEnter(Collider other)
    {
        PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
        if (player != null)
        {
            player.LoseLife(damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Vector3 position = transform.localPosition;
        position = new Vector3(position.x + speed * Time.deltaTime, position.y, position.z );
        transform.localPosition = position;
    }

    public void ChangeParent(Transform newParent)
    {
        transform.SetParent(newParent);
    }

    //Proyecto Github
}
