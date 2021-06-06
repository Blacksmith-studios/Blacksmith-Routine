using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //Utilisation du GameObject pour la font d'ecriture

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriterSpeed = 50f; //Unite de vitesse d'affichage

    public void Run(string textToType, TMP_Text textLabel) //Appelle la fonction d'affichage
    {
        StartCoroutine(routine:TypeText(textToType, textLabel)); //textToType designe le dialogue que l'on a ecrit, textLabel designe l'affichage de ce dernier physiquement
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel) //Fonction d'affichage à l'ecran
    {
        textLabel.text = string.Empty; //Enlever le remplissage automatique du canvas (purement esthetique out-game)

        yield return new WaitForSeconds(2); //Temporisation pour permettre de mieux gerer la viriable de vitesse, trop sensible sans cela

        float t = 0; //Unite du temps qui passe
        int charIndex = 0; //Nombre de caracteres qui va s'afficher a l'ecran pour chaque frame ecoulee

        while (charIndex < textToType.Length) //Boucle tant que les caracteres a afficher ne representent pas la taille des mots en tout
        {
            t += Time.deltaTime * typewriterSpeed; //t represente une lettre, et la fonction fait s'accumuler une lettre avec celles deja presentes par vitesse definie
            charIndex = Mathf.FloorToInt(t); //charIndex recupere le resultat de la ligne precedent est l'utilise pour afficher le total de lettres accumulees
            charIndex = Mathf.Clamp(value:charIndex, min:0, max:textToType.Length); //Fonction pour eviter les depassements, comme celui ou t continue de grossir alors que toutes les lettres ont deja ete affichees

            textLabel.text = textToType.Substring(startIndex:0, length:charIndex); //Fonction de recuperation du text

            yield return null; //Fonction pour temporiser l'affichage des lettres par frames
        }

        textLabel.text = textToType; //Verification si le text affiche est bien egal au text ecrit en amont
    }
}
