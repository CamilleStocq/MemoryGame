using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    const float CARD_SIZE = 1.0f;
    [SerializeField] private int rows = 4;
    [SerializeField] private int colums = 4;
    [SerializeField] private float gap = 0.5f;
    [SerializeField] private GameObject cardPrefab;
    

    private void Start()
    {
        if (rows * colums % 2 != 0)
        {
            Debug.LogError("The cards arent even number");
            return; // arrete le code, pas besoin de else
        }

        ObjectsCreation();
    }

    private void ObjectsCreation()
    {
        Vector3 position;
        for (float x = 0f; x < colums * (CARD_SIZE + gap); x += CARD_SIZE + gap) // pour creer le lignes
        {
            for (float z = 0f; z < rows * (CARD_SIZE + gap); z += CARD_SIZE + gap) // pour creer les colonnes
            {
                position = transform.position + Vector3.right * x + Vector3.forward * z;
                Instantiate(cardPrefab, position, Quaternion.identity); // creer un objet dans la scene en cours (si il existe deja ca crée un clone)
                // si on ne precise pas sa position il sera en (0,0), postion + rotation obligatoire
                // Quaterion.identity = rotation neutre (0,0)
            }

        }    
    }
    
}

