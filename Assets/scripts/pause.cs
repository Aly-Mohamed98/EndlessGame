using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
 
       public GameObject pausePanel;

    // Start is called before the first frame update

        public void pauseControl(){
        
         if (Time.timeScale == 1){
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
    }              
}
