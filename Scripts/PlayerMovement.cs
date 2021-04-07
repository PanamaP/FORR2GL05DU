using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // grunn breytur fyrir hraða
    private float speed = 10;
    private float sideways = 10;
    private float jump = 5;
    private Rigidbody leikmadur;
    

    void Start()
    {
        leikmadur = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //grunn breytur
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        Vector3 vel = leikmadur.velocity;
        vel.x = horizontal;
        vel.z = vertical;
        leikmadur.velocity = vel;

          
        // ef leikmaður fer fyrir neðan platform þá byrjar leikurinn á nýtt
        if (leikmadur.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // tékka á hvaða takka er ýtt á
        if (Input.GetKey("e"))
        {
            transform.Rotate(new Vector3(0, 5, 0));
        }
        if (Input.GetKey("q"))
        {
            transform.Rotate(new Vector3(0, -5, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * sideways * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * jump * Time.deltaTime;
        }
    }

    // heldur utan um arekstur a hluti
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "hlutur")
        {
            collision.collider.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().CountCoins(1);
        }

        if (collision.collider.tag == "hindrun")
        {
            FindObjectOfType<GameManager>().CountCoins(-1);
            FindObjectOfType<GameManager>().SetCountText();
        }
    }
}
