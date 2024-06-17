using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]//Inspector penceresinde gorunebilmesi icin
public class Sound : MonoBehaviour
{
    public string name;

    public AudioClip clip;
    
    [Range(0f,1f)]
    public float volume;

    [Range(.1f,3f)]
    public float pitch;

    [HideInInspector]//unity editorunde gizli kalmali ama scrip icinde kullanilmali
    public AudioSource source;
}
