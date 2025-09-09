using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))] //comportement obligatoire pour que le code fonctionne, il faut qu'il ai ca 

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f; // one = 1,1,1
    [SerializeField] private Color baseColor = Color.gray;
    [SerializeField] private float ChangeColorTime = 1f;

    private Vector3 memoScale; // vector3 sans valeur de base = 0
    private Color color;
    private int indexColor;
    private CardManager manager;

    public bool IsFaceUp { get; private set; } = false; // propriété qu'on peut lire de l'exterieur mais pas modifiable de l'exterieur

    private void OnMouseDown()
    {
        manager.CardIsClicked(this); //on se passe sois meme avec le "this"
    }

    private void OnMouseEnter()
    {
        memoScale = transform.localScale; // local par rapport au parent ( pour le scale il n'existe que ca mais pour location et rotation on eut choisir)
        transform.localScale = scaleOnFocus;
    }

    private void OnMouseExit()
    {
        transform.localScale = memoScale;
    }


    public void Initialize(Color color, int indexColor, CardManager manager)
    {
        this.color = color;
        this.indexColor = indexColor;
        this.manager = manager;

        ChangeColor(baseColor);
        IsFaceUp = false; // à l'initialisation face down
    }

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    public void FaceUp()
    {
        // ChangeColor(color); // fait changer la couleur de base vers sa couleur random
        StartCoroutine(ChangeColorWithLerp(color));
        IsFaceUp = true;
    }

    public void FaceDown()
    {
        // ChangeColor(color);
        StartCoroutine(ChangeColorWithLerp(baseColor));
        IsFaceUp = false; // on la retourne dans le sens ou on ne voit pas la couleur 
    }

    // coroutine s'execute en parallele du programme
    private IEnumerator ChangeColorWithLerp(Color color) // elle DOIT etre un IEnumerator !!!!! 
    {
        float timer = 0f;
        Color startColor = GetComponent<Renderer>().material.color;

        while (timer < ChangeColorTime)
        {
            timer += Time.deltaTime; // ajouter du temps au timer

            ChangeColor(Color.Lerp(startColor, color, timer / ChangeColorTime));
            // coroutine va toujours avec un yield return, genere l'attente 
            yield return new WaitForEndOfFrame();  // => yield return null
        }
        ChangeColor(color);
    }
}