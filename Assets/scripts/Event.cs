using UnityEngine.SceneManagement;
using UnityEngine;

public class Event : MonoBehaviour
{
    public void ReplayGame(){
        SceneManager.LoadScene("Game");
    }
    public void QuitGame(){
        Application.Quit(); 
    }


}
