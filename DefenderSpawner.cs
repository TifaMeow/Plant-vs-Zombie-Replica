using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    //[SerializeField]
    Defender defender;
    private void OnMouseDown()
    {
        
        Vector2 gridWorldPos = GetSquareClicked();
        //no overlay defenders on one square
        //check there is no defender in clicked place
        var defenders = FindObjectsOfType<Defender>();
        foreach (var defender in defenders)
        {
            if ((Vector2)defender.transform.position == gridWorldPos)
            {
                return;
            }
        }
        AttemptToPlaceDefenderAt(gridWorldPos);
    }

    public void SetSelectedDefender(Defender defenderToSelect) {
    
            defender = defenderToSelect;
       
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos) {

        var starDisplay = FindObjectOfType<StarDisplay>();
        //if (defender == null)
        //{
        //    Debug.Log("Please select a valid defender.");
        //    return;
        //}
        int defenderCost = defender.GetStarCost();
        //if we have enought stars
        //spawn defender
        //spend stars
        if (starDisplay && starDisplay.HasEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }
    private Vector2 GetSquareClicked() {

        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        //Debug.Log("Grid Pos clicked: x = " + gridPos.x + " & y = " + gridPos.y);

        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float gridX = Mathf.RoundToInt(rawWorldPos.x);
        float gridY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(gridX, gridY);
    }
    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, Quaternion.identity) as Defender;
    }

}
