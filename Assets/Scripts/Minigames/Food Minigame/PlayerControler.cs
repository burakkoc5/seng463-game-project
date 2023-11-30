using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Vector2 rawInput;
    [SerializeField] private float moveSpeed = 5f;

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3.3f, 3.3f), transform.position.y, transform.position.z);
        transform.position += new Vector3(rawInput.x * moveSpeed * Time.deltaTime,0,0);
    }
    
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
