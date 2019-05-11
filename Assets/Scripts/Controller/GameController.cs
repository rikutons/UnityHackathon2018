using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject workerPrefab;
    public GameObject buildingPrefab;
    public GameObject itemControllerObject;
    public GameObject audioPlayerObject;
    public GameObject buildingScrollerObject;
    public Text clearCountText;
    public Text stageText;
    public GameObject clearImage;
    public GameObject gameOverImage;
    public GameObject tutorialTextBoard;
    [HideInInspector]
    public bool isJumped;
    [HideInInspector]
    public bool isCleared;

    public int firstStage;

    private int nowStageNum;
    private bool isGameOver;
    private int clearSecnods;
    private ItemController itemController;
    private AudioPlayer audioPlayer;
    private BuildingsScroller buildingsScroller;
    private Subject<int> jumpSubject = new Subject<int>();
    private WorkerController officeWorkerController;

    private void Start()
    {
        nowStageNum = firstStage;
        buildingScrollerObject.transform.position = new Vector3(firstStage * -30, 0, 0);
        isGameOver = false;
        itemController = itemControllerObject.GetComponent<ItemController>();
        audioPlayer = audioPlayerObject.GetComponent<AudioPlayer>();
        buildingsScroller = buildingScrollerObject.GetComponent<BuildingsScroller>();
        StartStage();
    }

    public void StartStage()
    {
        Debug.Log("Stage " + nowStageNum.ToString() + " Started");
        isJumped = false;
        isCleared = false;
        audioPlayer.Play(0, AudioKind.BGM);
        var stageData = Stages.stageData[nowStageNum];

        SetWorkers(stageData.workers);

        itemController.Init(stageData.items);
        this.clearSecnods = stageData.clearSeconds;
        stageText.text = "Stage" + (nowStageNum + 1).ToString() + "/5";
        if (nowStageNum == 0)
        {
            stageText.text += "(tutorial)";
            tutorialTextBoard.SetActive(true);
        }
    }

    void SetWorkers(WorkerData[] workers)
    {
        foreach (var worker in workers)
        {
            var workerObject = Instantiate(workerPrefab);
            workerObject.transform.position = worker.pos;
            var workerController = workerObject.GetComponent<WorkerController>();
            workerController.jumpAngle = worker.jumpAngle;
            workerController.jumpPower = worker.jumpPower;
            workerController.SubscribeJumpSubject(jumpSubject);
        }
    }

    public void JumpButton_Click()
    {
        if (isJumped) return;
        tutorialTextBoard.SetActive(false);
        isJumped = true;
        jumpSubject.OnNext(0);
        float time = 0;
        var disposable = new SingleAssignmentDisposable();
        disposable.Disposable = this.UpdateAsObservable().
            Subscribe(_ =>
            {
                if (isGameOver)
                {
                    disposable.Dispose();
                }
                else if (isCleared)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        nowStageNum++;
                        time = 0;
                        if (Stages.stageData.Length > nowStageNum)
                        {
                            clearImage.SetActive(false);
                            Reflesher.Reflesh();
                            buildingsScroller.Scroll();
                            disposable.Dispose();
                        }
                        else
                        {
                            SceneManager.LoadScene("GameClearScene");
                        }
                    }
                }
                else if (time > clearSecnods)
                {
                    StageClear();
                }
                else
                {
                    time += Time.deltaTime;
                    clearCountText.text = "クリアまで " + (clearSecnods - (int)time).ToString() + "秒";
                }
            });
    }

    private void StageClear()
    {
        isCleared = true;
        clearImage.SetActive(true);
        audioPlayer.Play(1, AudioKind.BGM);
        clearCountText.text = "";
    }

    public void GameOver()
    {
        if (isCleared) return;
        isGameOver = true;
        gameOverImage.SetActive(true);
        clearCountText.text = "";
        var disposable = new SingleAssignmentDisposable();
        disposable.Disposable = this.UpdateAsObservable().Where(_ => isJumped).Subscribe(_ =>
        {
            if (Input.anyKey)
            {
                gameOverImage.SetActive(false);
                Reflesher.Reflesh();
                StartStage();
                isGameOver = false;
                disposable.Dispose();
            }
        });
    }
}
