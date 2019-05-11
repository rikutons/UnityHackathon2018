using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveOpeningCamera : MonoBehaviour
{
    Vector3 target1 = new Vector3(12, 34, -16);
    Vector3 target2 = new Vector3(26, 15, -18);
    Vector3 target3 = new Vector3(3, 15, -18);
    public GameObject opening;
    public GameObject cube;
    public int a = 0;
    public AudioSource pageAudio;
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(12, 44, -16);
    }


    // Update is called once per frame
    void Update()
    {
        if (a ==1)
        {
            Move1();
        }
        else if (a == 2)
        {
            Move2();
        }
        else if (a == 3)
        {
            Move3();
        }
        else if (a == 4)
        {
            Object.Destroy(opening);
            Object.Destroy(cube);
        }
        else if(a==5)
        {
            SceneManager.LoadScene("MainGameScene");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pageAudio.Play();
            a++;
        }
    }

    void Sleep()
    {
        System.Threading.Thread.Sleep(1000);
    }

    void Move1()
    {
        transform.position = Vector3.MoveTowards(transform.position, target1, 1);
    }

    void Move2()
    {
        transform.position = Vector3.MoveTowards(transform.position, target2, 1);
    }

    void Move3()
    {
        transform.position = Vector3.MoveTowards(transform.position, target3, 1);
    }
}
       
