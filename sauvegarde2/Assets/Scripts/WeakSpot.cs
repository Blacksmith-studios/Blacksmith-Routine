using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision) //Fonction de collision (Uniquement avec deux entites avec le IsTrigger active et dont au moins l'une des deux a un Collider2D !)
    {
        if (collision.CompareTag("Player")) //La fonction est prise en compte uniquement si c'est avec le tag "Player" qu'elle a lieu
        {
            Destroy(objectToDestroy); //Destruction (et non disparition) de l'entite
        }
    }
}