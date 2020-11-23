using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    private int timer = 0;
    public static int currentMaterial = 0;
    public Material[] materialsAll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer >= 500)
        {
            FindObjectOfType<AudioManager>().playsound("switch");            

            if (currentMaterial > 2)
            {
                currentMaterial = 0;
            }
            this.gameObject.GetComponent<MeshRenderer>().material = materialsAll[currentMaterial];
            currentMaterial++;
            timer = 0;
        }
        
    }
}
