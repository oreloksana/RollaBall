using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    private Rigidbody rb;

    private int count;
    // Text felds
    public Text countText, winText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        setCount();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cube")
        {
            Destroy(other.gameObject);
            count++;
            setCount ();
        }
    }

    void setCount()
    {
        countText.text ="Count = " + count.ToString ();
        if (count >= 8)
            winText.text = "You win!!!";

    }
}
