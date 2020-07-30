using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Health level timer in seconds")]
    [SerializeField] float levelTime = 10;
    bool levelFinishedTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinishedTriggered)
        {
            return;
        }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool timerFished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFished) {
            //Debug.Log("Level Time Expire!");
            FindObjectOfType<LevelController>().LevelTimerFinished();
            levelFinishedTriggered = true;
        }
    }
}
