using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ButtonAction : MonoBehaviour {
    public float time;
    private bool inside;
    public bool reset;
    public bool exit;
    public GameObject image;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inside)
        {
            if (!image.activeSelf)
            {
                image.SetActive(true);
            }
            image.GetComponent<Image>().fillAmount += 1f / time * Time.deltaTime;
        }

        if (image.GetComponent<Image>().fillAmount == 1)
        {
            if (reset)
            {
                Restart();
            }else if (exit)
            {
                Quit();
            }
        }
	}

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void InsideButton()
    {
        if (!inside)
        {
            inside = true;
        }
    }

    public void ExitButton()
    {
        inside = false;
        image.SetActive(false);
        image.GetComponent<Image>().fillAmount = 0;
    }
}
