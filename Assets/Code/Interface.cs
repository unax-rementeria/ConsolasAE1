using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    public TMP_Text textSpeed;
    public Rigidbody player;

    void FixedUpdate()
    {
        textSpeed.text = "Speed: " + (int)player.linearVelocity.magnitude + " m/s";
    }
}
