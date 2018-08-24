using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] PlayerControl playerControl;
    GameObject cam;
    Vector3 movement;
    public MySceneManagement mySceneManagement;

    float camOrigXPos;
    [SerializeField] float camLeftBound = 10f;
    [SerializeField] float camRightBound = 10f;
    float camOffset = 0f;
    float speed = 0f;
    
	void Start()
    {
		cam = GameObject.Find("Main Camera");
        speed = playerControl.walkSpeed;
        camOrigXPos = transform.position.x;
        camOffset = transform.position.x - playerControl.transform.position.x;
        Debug.Log("Offset = " + camOffset);
    }

	void Update()
    {
        if (!mySceneManagement.inDialogue)
        {

            movement = Vector3.zero;
            speed = playerControl.walkSpeed;
            camOffset = transform.position.x - playerControl.transform.position.x;

            if (Input.GetKey("left"))
            {
                if (cam.transform.position.x > camLeftBound)
                {
                    if (camOffset > 0)
                    {
                        transform.Translate(Vector3.right * -speed * Time.deltaTime);
                    }
                }
            }

            else if (Input.GetKey("right"))
            {
                if (cam.transform.position.x < camRightBound)
                {
                    if (camOffset < 0)
                    {
                        transform.Translate(Vector3.right * speed * Time.deltaTime);
                    }
                }
            }
        }
	}
}

