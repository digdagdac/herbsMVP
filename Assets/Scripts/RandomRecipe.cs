using UnityEngine;

public class RandomRecipe : MonoBehaviour
{
    public GameObject[] recipe = new GameObject[5];//탕 슬롯 마다 들어갈 레시피
    public bool rastRecipe = false;//2개짜리 레시피인지 3개 짜리 레시피인지 판별을 위한 마지막 레시피 자리
    int recipeSelect = 0;//여러번 쓰는 랜덤 값


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
