using System.Collections;
using UnityEngine;

public class SoldierController : MonoBehaviour {
    static Animator anim;
    public float speed = 10.0f;
    public float rotationSpeed = 10.0f;
    private float mouseX, mouseY;
    public float mouseSensitivity = 10f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    
    void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        print(rotation);
        transform.Translate(rotation, 0, translation);
        //transform.Rotate(rotation, 0, 0);
        
        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(0f, yaw, 0.0f);
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        //walking
        if (translation != 0 && rotation != 0)
        {
            //anim.SetBool("IsWalking", true);
            if (rotation < 0)
            {
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);
            }
            else
            {
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
            }
        }
        else if (translation != 0)
        {
            anim.SetBool("IsWalking", true);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }
        else if (rotation != 0)
        {
            if (rotation < 0)
            {
                anim.SetBool("Left", true);
                anim.SetBool("Right", false);
            }
            else
            {
                anim.SetBool("Right", true);
                anim.SetBool("Left", false);
            }
        }
        else if (translation == 0 && rotation == 0)
        {
            anim.SetBool("IsWalking", false);
            anim.SetBool("Left", false);
            anim.SetBool("Right", false);
        }



    }
}
