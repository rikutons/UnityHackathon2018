using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrager : MonoBehaviour
{
    private GameController gameController;

    public void OnDrag()
    {
        if (gameController == null) LoadGameController();
        if (gameController.isJumped) return;
        Vector3 TapPos = Input.mousePosition;
        TapPos.z = 10f;
        Vector3 wPos = Camera.main.ScreenToWorldPoint(TapPos);
        transform.position = new Vector3(Mathf.Clamp(wPos.x, -5f, 100f), wPos.y, wPos.z);
    }

    private void LoadGameController()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

    }
}