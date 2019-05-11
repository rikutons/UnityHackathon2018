using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int itemID;
    public float angle;
    public Vector3 customPos;
}
public class ItemController : MonoBehaviour
{
    public Vector2 itemPos;
    public float itemDistanceY;
    public GameObject[] itemObjects;

    private Item[] items;
    public void Init(Item[] items_)
    {
        items = items_;
        for (int i = 0; i < items.Length; i++)
        {
            var itemObject = Instantiate(itemObjects[items[i].itemID]);
            itemObject.transform.position = new Vector3(itemPos.x, itemPos.y - itemDistanceY * i, 0) + items[i].customPos;
            itemObject.transform.Rotate(0, 0, items[i].angle);
        }
    }

}
