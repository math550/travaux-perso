using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : NetworkBehaviour
{

    public GameObject boost;
    

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;


    private GameObject items;
    private Quaternion spawnRotation;

    private bool isItem1 = false;
    private bool isItem2 = false;
    private bool isItem3 = false;
    private bool isItem4 = false;


    private Transform itemThatWasDestroyed;


    public override void OnStartServer()
    {
        EventsManager.AddListener("OnItemDestroyed", CheckItemDestroyed);
        EventsManager.AddListener("ItemDestroyed", OnItemDestroyed);

       

        spawnRotation = Quaternion.Euler(0f, 0f, 0f);
        GameObject item1 = (GameObject)Instantiate(boost, spawnPoint1.position, spawnRotation) as GameObject;
        GameObject item2 = (GameObject)Instantiate(boost, spawnPoint2.position, spawnRotation) as GameObject;
        GameObject item3 = (GameObject)Instantiate(boost, spawnPoint3.position, spawnRotation) as GameObject;
        GameObject item4 = (GameObject)Instantiate(boost, spawnPoint4.position, spawnRotation) as GameObject;

        GameObject items = GameObject.Find("Items");

        item1.transform.SetParent(items.transform);
        item2.transform.SetParent(items.transform);
        item3.transform.SetParent(items.transform);
        item4.transform.SetParent(items.transform);



        NetworkServer.Spawn(item1);
        NetworkServer.Spawn(item2);
        NetworkServer.Spawn(item3);
        NetworkServer.Spawn(item4);
    }

    private void CheckItemDestroyed()
    {
        StartCoroutine(ItemDestroyed());
    }

    IEnumerator ItemDestroyed()
    {
        yield return new WaitForSeconds(2.0f);

        items = GameObject.Find("Items");

        if (items.transform.childCount < 4)
        {
            EventsManager.TriggerListener("ItemDestroyed");
            Debug.Log("OnItemDestroyed reached");
        }

    }

    private void OnItemDestroyed()
    {
        foreach (Transform child in items.transform)
        {
            Debug.Log(child.position);

            if (child.position == spawnPoint1.position)
            {
                isItem1 = true;
            }
            else if (child.position == spawnPoint2.position)
            {
                isItem2 = true;
            }
            else if (child.position == spawnPoint3.position)
            {
                isItem3 = true;
            }
            else if (child.position == spawnPoint4.position)
            {
                isItem4 = true;
            }
        }

        if (!isItem1)
        {
            Debug.Log("Item1 is missing !");
            GameObject item1 = (GameObject)Instantiate(boost, spawnPoint1.position, spawnRotation) as GameObject;
            item1.transform.SetParent(items.transform);
            NetworkServer.Spawn(item1);
        }
        if (!isItem2)
        {
            Debug.Log("Item2 is missing !");
            GameObject item2 = (GameObject)Instantiate(boost, spawnPoint2.position, spawnRotation) as GameObject;
            item2.transform.SetParent(items.transform);
            NetworkServer.Spawn(item2);
        }
        if (!isItem3)
        {
            Debug.Log("Item3 is missing !");
            GameObject item3 = (GameObject)Instantiate(boost, spawnPoint3.position, spawnRotation) as GameObject;
            item3.transform.SetParent(items.transform);
            NetworkServer.Spawn(item3);
        }
        if (!isItem4)
        {
            Debug.Log("Item4 is missing !");
            GameObject item4 = (GameObject)Instantiate(boost, spawnPoint4.position, spawnRotation) as GameObject;
            item4.transform.SetParent(items.transform);
            NetworkServer.Spawn(item4);
        }
        isItem1 = false;
        isItem2 = false;
        isItem3 = false;
        isItem4 = false;
    }
}