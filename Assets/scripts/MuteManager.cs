using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMute;
    // Start is called before the first frame update
    void Start()
    {
        isMute = false;
    }
    public void mutePressed(){
        isMute = !isMute;
        AudioListener.pause = isMute;
    }
}
