using System.Collections;
using UnityEngine;

public class CameraRotate : MonoBehaviour {
    private float pitch = 0.0f;
    public float speedV = 2.0f;


    // Use this for initialization
    void Start () {
      
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
	}

    // Update is called once per frame
    void Update()
    {
        pitch -= speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(pitch, 0.0f, 0.0f);
       
    }

  


}

