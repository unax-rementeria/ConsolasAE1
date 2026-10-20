using UnityEngine;
using System.Collections.Generic;
using TMPro;


[System.Serializable]
public class checkpoint
{
    public Collider checkpointCollider;
    public bool isActive;
}

public class checkpoints : MonoBehaviour
{
    public List<checkpoint> checkpointArray;
    bool allActive = false;
    [SerializeField] private int lapCount = 0;

    public TMP_Text lapCountText;


    private void FixedUpdate()
    {
        //if all checkpoints are active, reset them except for the first one
        for (int i = 0; i < checkpointArray.Count; i++)
        {
            if (checkpointArray[i].isActive == false)
            {
                allActive = false;
                break;
            }
            else if (i == checkpointArray.Count - 1 && checkpointArray[i].isActive == true)
            {
                allActive = true;

                lapCount++;
                lapCountText.text = "Laps Completed: " + lapCount;

                for (int j = 1; j < checkpointArray.Count; j++)
                {
                    checkpointArray[j].isActive = false;
                }
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Debug.Log("Player collided with checkpoint!");
            for (int i = 0; i < checkpointArray.Count; i++)
            {
                //first checkpoint is always active
                if (checkpointArray[i].checkpointCollider == other && checkpointArray[i-1].isActive)
                {
                    checkpointArray[i].isActive = true;
                    Debug.Log("Checkpoint " + i + " activated!");
                }
            }
            
        }
    }
}
