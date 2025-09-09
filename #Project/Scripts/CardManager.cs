using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeFaceDown = 1f;
    private List<CardBehaviour> deck;
    private Color[] colors;

    private CardBehaviour memoCard = null;
    private int combinaisonsFound = 0;

    public void Initialize(List<CardBehaviour> deck, Color[] colors)
    {
        this.deck = deck; //constructeur
        this.colors = colors; //constructeur

        memoCard = null;
        combinaisonsFound = 0;

        List<int> colorIndices = new List<int>();

        for (int i = 0; i < deck.Count; i++)
        {
            colorIndices.Add(i / 2);
        }

        // Mélange les indices et assigne les cartes
        for (int i = 0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            (colorIndices[i], colorIndices[rand]) = (colorIndices[rand], colorIndices[i]);

            int colorIndex = colorIndices[i];
            Color color = colors[colorIndex];
            deck[i].Initialize(color, colorIndex, this);
        }
    }

    public void CardIsClicked(CardBehaviour card)
    {
        // reaction des cartes ici (face visible)
        if (card.IsFaceUp) return; // si elle est retournée on ne peut rien faire 

        card.FaceUp();

        if (memoCard != null)
        {
            if (card.IndexColor != memoCard.IndexColor)// si on a une carte on compare les couleur
            {
                // Debug.Log("bravoooo !!!! C'est les memes");
                memoCard.FaceDown(delayBeforeFaceDown);
                card.FaceDown(delayBeforeFaceDown);
            }
            else
            {
                // compter le nbr de combinaison de cartes trouvé
                combinaisonsFound++;

                if (combinaisonsFound == deck.Count / 2)
                {
                    SceneManager.LoadScene("Victory"); // on change de scene 
                    //victoryManager
                }
            }

            memoCard = null;
        }
        else
        {
            memoCard = card; // si on a pas de carte c'est notre carte 1 
        }
    }
}