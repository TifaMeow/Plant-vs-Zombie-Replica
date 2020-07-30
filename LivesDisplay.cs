using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{

    [SerializeField] int lives = 5;
    [SerializeField] int damage = 1;
    private AudioSource failSourceClip;
    Text livesText;

    void Start()
    {
       failSourceClip = GetComponent<AudioSource>();
       livesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (lives >= 0)
        {
            livesText.text = lives.ToString();
        }
        
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();
        if (lives <= 0)
        {
            //FindObjectOfType<LevelLoader>().LoadYouLoseScene();
            //FindObjectOfType<LevelController>().HandleLoseCondition();
            LevelController controller = FindObjectOfType<LevelController>();
            failSourceClip.Play();
            controller.HandleLoseCondition();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
