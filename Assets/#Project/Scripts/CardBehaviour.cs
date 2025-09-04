using UnityEngine;

public class CardBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 scaleOnFocus = Vector3.one * 1.5f; // one = 1,1,1
    private Vector3 memoScale; // vector3 sans valeur de base = 0

    private void OnMouseEnter()
    {
        memoScale = transform.localScale; // local par rapport au parent ( pour le scale il n'existe que ca mais pour location et rotation on eut choisir)
        transform.localScale = scaleOnFocus;
    }
}
