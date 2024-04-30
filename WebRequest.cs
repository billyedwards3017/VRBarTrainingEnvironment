using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour
{

    public RecipeInfo RecipeInfo;

    private void Start()
    {
        RecipeInfo = GetComponent<RecipeInfo>();

        //on launch, the program will run the getrecipe coroutine, it must be a coroutine as it may takw time to get a response.
        StartCoroutine(GetRecipes("http://localhost/DissertationFolder/GetRecipes.php"));


    }

    IEnumerator GetRecipes(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                switch (webRequest.result)
                {
                //checks for any errors with retrieving the data
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.DataProcessingError:
                        Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.ProtocolError:
                        Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                        break;
                    case UnityWebRequest.Result.Success:
                    //in the case of a successful retreival of data, the entirety of the results is stored as a string, to be parsed
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                        string jsonRecipes = webRequest.downloadHandler.text;
                       // RecipeInfo Recipes = JsonUtility.FromJson<RecipeInfo>(jsonRecipes);
                        print(jsonRecipes);
                    
                        //RecipeInfo.SetRecipe();
                        print("Recieved info");
                        break;
                }
        }
    }


}
