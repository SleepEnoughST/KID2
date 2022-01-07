using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class passSystem : MonoBehaviour
{
    public string nameTarget = "¤p¬õ´U";
    public UnityEvent onPass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == nameTarget) onPass.Invoke();
    }
}
