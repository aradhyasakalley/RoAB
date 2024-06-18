using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public GameObject winTextObject;
    public TextMeshProUGUI countText;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winTextObject.SetActive(false);

    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void OnJump(InputValue jumpValue)
    {
        Debug.Log("Jumping!!!");
        rb.AddForce(Vector3.up*5f,ForceMode.Impulse);

    }
    void SetCountText()
    {
        countText.text = "Score : " + count.ToString();
        if (count >= 12)
        {
            //winTextObject.SetActive(true);
            SceneManager.LoadSceneAsync(2);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            Debug.Log(count);
            SetCountText();
        }
    }

}
