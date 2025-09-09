using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    List<CardBehaviour> deck;
    Color[] colors;

    public void Initialize(List<CardBehaviour> deck, Color[] colors)
    {
        this.colors = colors; //constructeur
        this.deck = deck; //constructeur

        List<Color> doubleColor = new List<Color>();


        // int colorIndex;
        // for (int index = 0; index < deck.Count; index++)
        // {
        //     colorIndex = Random.Range(0, colors.Length);
        //     deck[index].Initialize(colors[colorIndex], colorIndex, this); // this pour se passer sois meme

        // }

        for (int index = 0; index < deck.Count / 2; index++)
        {
            doubleColor.Add(colors[index]);
            doubleColor.Add(colors[index]);
        }

        for (int i = 0; i < doubleColor.Count; i++)
        {
            Color temp = doubleColor[i];
            int randomIndex = Random.Range(i, doubleColor.Count);
            doubleColor[i] = doubleColor[randomIndex];
            doubleColor[randomIndex] = temp;
        }

        for (int j = 0; j < deck.Count; j++)
        {
            deck[j].Initialize(doubleColor[j], j, this);
        }
    }
}
