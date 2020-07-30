using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    public Defender defenderPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(144, 111, 111, 255);
            
        }
        GetComponent<SpriteRenderer>().color = Color.white;


        DefenderSpawner ds = FindObjectOfType<DefenderSpawner>();
        //Debug.Log("Defender Spawner found! ds == null? " + ds == null);
        ds.SetSelectedDefender(defenderPrefab);
    }
}
