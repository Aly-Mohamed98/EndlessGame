using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControler : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public static float speed;
    private float desiredLane =  0.1f; 
    public float laneDistance = 4.0f; //distance between 2 lanes
    private float playerY = 1.30f;
    private bool platform = true;
    public GameObject wheel;
    private int count;
    private int [] speeds = {50, 100, 150, 200};
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        count = 0;
        controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        int incSpeed = PlayerManager.score - speeds[count];
        if(incSpeed == 0 || incSpeed == 5){
            speed+=2;
            count++;
        }

        direction.z = speed;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            desiredLane+=2.5f;
            if(desiredLane >= 5.0f){
                desiredLane = 2.5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            desiredLane-=2.5f;
            if(desiredLane < -5.0f){
                desiredLane = -2.5f;
            }
        }
        if (platform){
            playerY = 1.3f;
        }
        else if (!platform){
            playerY = 8.7f;
        }
        Vector3 targetposition = new Vector3(desiredLane, playerY, transform.position.z);
        if (desiredLane == 0)
        {
            targetposition += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetposition += Vector3.right * laneDistance;
        }
        transform.position = targetposition;
        controller.center = controller.center;
        if (Input.GetKeyDown(KeyCode.C)){
            
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().playsound("jump");            
            if (platform)
            {
                platform = false;
            }
            else
            {
                platform = true;
            }
        }

}

    private void FixedUpdate(){
        controller.Move(direction*Time.deltaTime);

    }
    private void OnControllerColliderHit (ControllerColliderHit hit){
        if (hit.transform.tag == "obstacle"){
            Destroy(hit.gameObject);
            FindObjectOfType<AudioManager>().playsound("obstacle");
            PlayerManager.PlayerHealth--;
        }
        else if (hit.transform.tag == "orbs"){
            FindObjectOfType<AudioManager>().playsound("Collect");
            Material mesh = wheel.gameObject.GetComponent<MeshRenderer>().material;
            Material mesh2 = hit.gameObject.GetComponent<MeshRenderer>().material;
            Destroy(hit.gameObject); 
            if (platform){
                if (mesh.color == mesh2.color){
                    PlayerManager.score+= 10;
                }
                else{
                    PlayerManager.score-= 5;
                }
                
            }
            else{
                if (!(mesh.color == mesh2.color)){
                    PlayerManager.score+= 10;
                }
                else{
                    PlayerManager.score-= 5;
                }
            }
        }
        if (PlayerManager.PlayerHealth == 0)
        {
            Time.timeScale = 0;
            FindObjectOfType<AudioManager>().playsound("GameOver");
            PlayerManager.gameOver = true;
        }
    } 
}
