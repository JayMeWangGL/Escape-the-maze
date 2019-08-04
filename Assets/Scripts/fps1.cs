using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fps1 : MonoBehaviour
{
    CharacterController playerController;
    Vector3 direction;
    
    
    public float gravity = 7f;
    public float mousespeed = 5f;
    public float minmouseY = -45f;
    public float maxmouseY = 45f;
    float RotationY = 0f;
    float RotationX = 0f;
    public Transform agretctCamera;

    private PlayerController a;
    // Use this for initialization	
    void Start () {
        a = GetComponent<PlayerController>();
        
        playerController = this.GetComponent<CharacterController>();
        //Screen.lockCursor = true;
    }
    // Update is called once per frame	
    void Update () {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        
        transform.Translate(_horizontal * Time.deltaTime * a.moveSpeed, a.jumpPower , _vertical * Time.deltaTime * a.moveSpeed);

        RotationX += agretctCamera.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mousespeed;
        RotationY -= Input.GetAxis("Mouse Y") * mousespeed;
        RotationY = Mathf.Clamp(RotationY,minmouseY,maxmouseY);
        this.transform.eulerAngles = new Vector3(0,RotationX,0);
        agretctCamera.transform.eulerAngles = new Vector3(RotationY, RotationX, 0);	}
}


