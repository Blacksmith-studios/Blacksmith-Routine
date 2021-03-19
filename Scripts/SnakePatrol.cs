using UnityEngine;

public class SnakePatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints; //Balise (waypoints) encadrant le deplacement du personnage d'un point a un autre

    public SpriteRenderer graphics;
    private Transform target; //Representation des waypoints en tant qu'entite
    private int destPoint = 0; //Numeration du nombre de waypoints dans leur ordre de passage en tant que valeur

    void Start()
    {
        target = waypoints[0]; //Initialisation du premier waypoints a aller chercher
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position; //Fonction de deplacement vers le prochain waypoints
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) < 0.3f) //Changement de waypoints quand le personnage arrive a proximite d'un waypoints
        {
            destPoint = (destPoint + 1) % waypoints.Length; //Boucle permettant de repasser du dernier waypoints au premier
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX; //Fonction permettant le flip du sprite quand l'entite se deplace dans les valeurs negatives
        }
    }
}