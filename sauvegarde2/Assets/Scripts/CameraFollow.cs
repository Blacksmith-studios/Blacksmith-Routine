using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player; //Initialisation de l'objet sur lequel le focus de la camera va se faire
    public float timeOffset; //Initialisation de la valeur de deplacement de la caméra par rapport au temps
    public Vector3 posOffset; //Initialisation de la position de la camera par rapport a son focus

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset); //Fonction de deplacement de la camera vis-a-vis de son focus
    }
}