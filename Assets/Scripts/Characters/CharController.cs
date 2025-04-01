using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
    private GameObject ui;
    private Button moveButton;
    public bool waitingForMove = false;
    private float tileOffset = 0.65f;
    private float hillOffset = 1.075f;

    void Start()
    {
        ui = GameObject.FindWithTag("CharUI");
        ui.SetActive(false);
    }

    public void ShowUI()
    {
        ui.SetActive(true);
        moveButton = ui.transform.Find("MoveButton").GetComponent<Button>();
        moveButton.onClick.RemoveAllListeners();
        moveButton.onClick.AddListener(() => OnMoveButtonClick());
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }

    public void OnMoveButtonClick()
    {
        Debug.Log("Move button clicked! Waiting for tile selection.");
        waitingForMove = true;
        HideUI();
    }

    public void Move(TileData tile)
    {
        Debug.Log("Success!");
        Vector3 tilePos = tile.transform.position;
        if(!tile.isHill)
            this.transform.position = new Vector3(tilePos.x, tilePos.y + tileOffset, tilePos.z);
        else
            this.transform.position = new Vector3(tilePos.x, tilePos.y + hillOffset, tilePos.z);
    }
}
