using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody playerBody;
    private Camera playerCamera;
    public bool IsGrounded;
    public bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponentInChildren<Rigidbody>();
        playerCamera = GetComponentInChildren<Camera>();

        playerSpeed *= LevelManager.FPS_MODIFIER;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 baseforward = transform.position - playerCamera.transform.position;
        Vector3 forward = new Vector3(baseforward.x, 0.0f, baseforward.z);
        Vector3 baseBack = playerCamera.transform.position - transform.position;
        Vector3 back = new Vector3(baseBack.x, 0.0f, baseBack.z);
        Vector3 left = Vector3.Cross(forward, Vector3.up);
        Vector3 right = Vector3.Cross(back, Vector3.up);
    
        if (IsGrounded) {
            if (Input.GetAxisRaw("Vertical") == 1)
            {   
               
                playerBody.AddForce(Time.deltaTime*forward.normalized * playerSpeed);
                hasMoved = true;
            }
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                playerBody.AddForce(Time.deltaTime*back.normalized * playerSpeed);
                hasMoved = true;
            }
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                playerBody.AddForce(Time.deltaTime*right.normalized * playerSpeed);
                hasMoved = true;
            }
            if (Input.GetAxisRaw("Horizontal") == -1)
            {
                playerBody.AddForce(Time.deltaTime*left.normalized * playerSpeed);
                hasMoved = true;
            }

        }  else  {
            if (Input.GetKey(KeyCode.W))
            {
                playerBody.AddForce(Time.deltaTime*forward.normalized * playerSpeed* 0.3f);
                hasMoved = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerBody.AddForce(Time.deltaTime*back.normalized * playerSpeed * 0.3f);
                hasMoved = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerBody.AddForce(Time.deltaTime*right.normalized * playerSpeed * 0.3f);
                hasMoved = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerBody.AddForce(Time.deltaTime*left.normalized * playerSpeed * 0.3f);
                hasMoved = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Finish")){
           FindObjectOfType<LevelManager>().FinishLevel();
        }


    }


    void OnCollisionStay(Collision collisionInfo)
    {
        IsGrounded = true;
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        IsGrounded = false;
    }
}
