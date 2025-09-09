using UnityEngine;

[RequireComponent(typeof(Renderer))] //comportement obligatoire pour que le code fonctionne, il faut qu'il ai ca 

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f; // one = 1,1,1
    private Vector3 memoScale; // vector3 sans valeur de base = 0
    private Color color;
    private int indexColor;
    private CardManager manager;

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

        ChangeColor(color); // temporaire juste pour voir si les couleurs fonctionne
        
    }

    public void ChangeColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }
}
