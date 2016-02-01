using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Move : MonoBehaviour {
    private float gravity;
    public CharacterController controller;
    public CardboardHead head;
    public float speed;
    public int life = 3;
    public Text lifeText;
    public GameObject menu;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        lifeText.text = "Leben: " + life;
	}
	
    void FixedUpdate()
    {
        gravity -= 9.81f * Time.fixedDeltaTime;
        controller.Move(new Vector3(head.Gaze.direction.x * Time.fixedDeltaTime * speed, gravity, head.Gaze.direction.z * Time.fixedDeltaTime * speed));

        if (controller.isGrounded)
        {
            gravity = 0;
        }

    }

	// Update is called once per frame
	void Update () {
	    if(life <= 0)
        {
            Debug.Log("speed");
            speed = 0;
            menu.SetActive(true);
        }
	}

    public void OnTriggerEnter(Collider col)
    {
        Debug.Log("enemy");
        if (col.transform.name.StartsWith("enemy"))
        {
            life -= 1;
            lifeText.text = "Leben: " + life;
        }
        if (col.transform.name.StartsWith("finish"))
        {
            speed = 0;
            menu.SetActive(true);
        }
    }
}
