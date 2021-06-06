using UnityEngine;
using TMPro; //Utilisation du GameObject pour la font d'ecriture

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel; //Permet le lien entre le script et l'affichage des dialogues (canvas)

    private void Start() //Lancement du programme d'affichage des dialogues
    {
        GetComponent<TypewriterEffect>().Run(textToType:"This is a bit of text!\nHello you.", textLabel); //Test de text
    }
}