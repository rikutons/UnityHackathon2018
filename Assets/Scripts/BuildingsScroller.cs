using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
public class BuildingsScroller : MonoBehaviour
{
    public float speed;
    public int moveFrame;
    public GameObject gameControllerObject;

    private GameController gameController;

    private void Start()
    {
        gameController = gameControllerObject.GetComponent<GameController>();
    }
    public void Scroll()
    {
        this.UpdateAsObservable().Take(moveFrame).Subscribe(_ =>
        {
            transform.position += new Vector3(speed, 0, 0);
        },
        () => gameController.StartStage());

    }
}
