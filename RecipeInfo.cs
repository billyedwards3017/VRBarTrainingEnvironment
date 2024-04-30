using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeInfo : MonoBehaviour
{

    public int id;
    public string CocktailName;
    public string IngredientOne;
    public string IngredientTwo;
    public string IngredientThree;
    public bool IceRequired;
    public bool ShakenRequired;
    public string Garnish;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRecipe(int ID, string Name, string I1, string I2, string I3, bool Ice, bool Shake, string Garn)
    {
        //recipe info that will be retrieved from the database
        id = ID;
        CocktailName = Name;
        IngredientOne = I1;
        IngredientTwo = I2;
        IngredientThree = I3;
        IceRequired = Ice;
        ShakenRequired = Shake;
        Garnish = Garn;

    }
}
