using UnityEngine;

public class RandomRecipe : MonoBehaviour
{
    public GameObject[] recipe = new GameObject[5];//�� ���� ���� �� ������
    public bool rastRecipe = false;//2��¥�� ���������� 3�� ¥�� ���������� �Ǻ��� ���� ������ ������ �ڸ�
    int recipeSelect = 0;//������ ���� ���� ��


    // Start is called before the first frame update
    void Start()
    {
        recipeSelect = Random.Range(0, 5);
        recipe[recipeSelect].SetActive(true);

        if (rastRecipe == true)
        {
            recipeSelect = Random.Range(0, 2);
            if (recipeSelect == 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
