using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public GameObject enemySpawn;
    public CinemachineVirtualCamera cutsceneCamera;
    public Transform spawnPoint;
    public GameObject dialogueAwait;

    IEnumerator SpawnCoroutine()
    {
        while(dialogueAwait.activeSelf)
        {
            yield return new WaitForSeconds(1.0f);
        }
        cutsceneCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_ScreenY = 2.5f;
        for (int i = 0; i < 3; i++) 
        {
            Debug.Log("Spawned an enemy");
            Instantiate(enemySpawn, spawnPoint.transform.position, spawnPoint.transform.rotation);
            yield return new WaitForSeconds(1.0f);
        }
        cutsceneCamera.GetComponentInChildren<CinemachineFramingTransposer>().m_ScreenY = 0.25f;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Started");
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
