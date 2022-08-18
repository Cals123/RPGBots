using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogGiver : MonoBehaviour
{
    [SerializeField] TextAsset _dialog;

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<ThirdPersonMovement>();
        if (other.GetComponent<ThirdPersonMovement>() != null)
        {
            transform.LookAt(player.transform);
            FindObjectOfType<DialogController>().StartDialog(_dialog);
        }


    }
}
