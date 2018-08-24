using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManagement : MonoBehaviour {

    public int levelToLoad;
    public bool inDialogue = false;

    private void Awake()
    {
        inDialogue = false;
        //Time.timeScale = 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Something hit trigger");

        if (other.tag == "Player")
        {
            Debug.Log("Player hit trigger");
            SceneManager.LoadScene(levelToLoad);
        }
    }
    
    public void EnterDialogue()
    {
       // Time.timeScale = 0.01f;
        inDialogue = true;
    }

    public void EndDialogue()
    {
        //Time.timeScale = 1f;
        inDialogue = false;
    }
}
