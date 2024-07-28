using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject TextoFlotantePrefab;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        movement = new Vector2(moveInput, 0);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void MostrarTextoFlotante()
    {
        GameObject texto = Instantiate(TextoFlotantePrefab);
        texto.transform.position = new Vector3(this.gameObject.transform.position.x,
            this.gameObject.transform.position.y+4,
            this.gameObject.transform.position.z);
        texto.transform.SetParent(this.transform);
    }
}
