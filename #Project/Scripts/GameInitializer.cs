using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private int rows = 4;
    [SerializeField] private int colums = 4;
    [SerializeField] private GameObject cardPrefab;

    private void Start()
    {
        if (rows * colums % 2 != 0)
        {
            Debug.LogError("The cards arent even number");
            return;
        }
    }

}

