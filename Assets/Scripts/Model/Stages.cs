using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stages
{
    public static StageData[] stageData = new StageData[]{
        new StageData
        {
            items=new Item[]
            {
                new Item{ itemID=0 },
                new Item{itemID=1,customPos=new Vector3(14,1.63f,16)}
            },
            workers=new WorkerData[]
            {
                new WorkerData{jumpAngle=45,jumpPower=10,pos=new Vector3(-9.17f,2.79f,0) }
            },
            clearSeconds=4
        },
        new StageData
        {
            items=new Item[]
            {
                new Item{ itemID=0 },
                new Item{itemID=1,customPos=new Vector3(14,1.63f,16)},
                new Item{itemID=2,customPos=new Vector3(14,-2.2f,16)}
            },
            workers=new WorkerData[]
            {
                new WorkerData{jumpAngle=30,jumpPower=20,pos=new Vector3(-9.17f,2.79f,0) }
            },
            clearSeconds=6
        },
        new StageData
        {
            items=new Item[]
            {
                new Item{ itemID=0 },
                new Item{itemID=1,customPos=new Vector3(14,1.63f,16)},
            },
            workers=new WorkerData[]
            {
                new WorkerData{jumpAngle=80,jumpPower=15,pos=new Vector3(-9.17f,2.79f,0) }
            },
            clearSeconds=10
        },
        new StageData
        {
            items=new Item[]
            {
                new Item{itemID=4,customPos=new Vector3(14,3.63f,16)},
                new Item{itemID=5,customPos=new Vector3(14,1.63f,16)}
            },
            workers=new WorkerData[]
            {
                new WorkerData{jumpAngle=50,jumpPower=10,pos=new Vector3(-9.17f,2.99f,0) },
                new WorkerData{jumpAngle=80,jumpPower=10,pos=new Vector3(-5.27f,0.65f,0) }
            },
            clearSeconds=10
        },
        new StageData
        {
            items=new Item[]
            {
                new Item{ itemID=0 ,angle=20},
                new Item{ itemID=0 ,angle=20},
                new Item{itemID=4,customPos=new Vector3(14,-2.2f,16)}
            },
            workers=new WorkerData[]
            {
                new WorkerData{jumpAngle=70,jumpPower=14,pos=new Vector3(-9.17f,2.99f,0) },
                new WorkerData{jumpAngle=0,jumpPower=5,pos=new Vector3(-5.27f,0.65f,0) }
            },
            clearSeconds=10
        }
    };
}