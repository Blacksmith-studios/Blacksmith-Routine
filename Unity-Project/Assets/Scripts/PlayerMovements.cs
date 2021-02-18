using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    private Collider2D playerCol;
    private Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = transform.GetComponent<Collider2D>();
        playerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = transform.position;
        playerPos.x += Input.GetAxisRaw("Horizontal") * playerSpeed;
        transform.position = playerPos;
    }
}
