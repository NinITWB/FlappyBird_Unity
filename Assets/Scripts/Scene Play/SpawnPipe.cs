using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private float timeSpawn;

    private float timerSpawn;
    private GameObject clone;
    // Start is called before the first frame update
    void Start()
    {
        //clone = upPipe;
    }

    // Update is called once per frame
    void Update()
    {
        timerSpawn += Time.deltaTime;
        Spawn();    
    }

    private void Spawn()
    {
        /*if (timerSpawn >= timeSpawn)
        {
            GameObject newPipe = Instantiate(upPipe, new Vector3(3.2f, 3, 0), Quaternion.identity);
            //CreateParent(newPipe);
            newPipe.transform.SetParent(oParent.transform, false);
            oParent.GetComponent<BoxCollider2D>().offset = newPipe.transform.position;
            timerSpawn = 0;
        }*/


        /*if (timerSpawn >= timeSpawn)
        {
            GameObject go = Instantiate(clone, new Vector3(3.14f, -0.39f, 0), Quaternion.identity);
            float yPosPipeUp = Random.Range(2.67f, 5.65f);
            go.transform.GetChild(0).localPosition = new Vector3(0, yPosPipeUp, 0);
            go.transform.GetChild(1).localPosition = new Vector3(0, yPosPipeUp - Random.Range(4.55f, 4.82f), 0);
            go.GetComponent<BoxCollider2D>().offset = go.transform.GetChild(0).localPosition + go.transform.GetChild(1).localPosition;
            go.GetComponent<BoxCollider2D>().size = new Vector2(0.601028f, 0.5194198f);
            clone = go;
            timerSpawn = 0;
        }*/

        /*if (GameManager.Instance != null)
        {
            if (GameManager.Instance.IsGameOver)
                return;
        }*/

        timeSpawn = GameManager.Instance.timeRecover;

        if (timerSpawn >= timeSpawn)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(-4.3f, -1.46f), transform.position.z);
            ObjectPooling();
            timerSpawn = 0;
        }

    }

    private void ObjectPooling()
    {
        pipes[ObjectState()].transform.localPosition = transform.position;
        pipes[ObjectState()].SetActive(true);
    }
    
    private int ObjectState()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            if (!pipes[i].activeInHierarchy)
            {
                return i;
            }
        }

        return 0;
    }
}
