using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    [SerializeField] int coinValue;
    Vector3 newPosition;
    float height;
    private void Start()
    {
        height = transform.localPosition.y;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            newPosition = new Vector3(Random.Range(-10, 10), height, Random.Range(-10, 10));
            transform.position = newPosition;
            print("Position " + transform.position.y);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerScore door;
        door = other.gameObject.GetComponent<PlayerScore>();

        if (door != null)
        {
            door.AddScore(coinValue);

            AudioSource coinSound;
            coinSound = GetComponent<AudioSource>();
            coinSound.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            Destroy(gameObject, 1f);
            //newPosition = new Vector3(Random.Range(-10, 10), height, Random.Range(-10, 10));
            //transform.position = newPosition;
            //print("Position " + transform.position.y);
        }

        //if (other.gameObject.CompareTag("Walls"))
        //{
        //    newPosition = new Vector3(Random.Range(-10, 10), height, Random.Range(-10, 10));
        //    transform.position = newPosition;
        //    print("Position " + transform.position.y);
        //}
    }
}