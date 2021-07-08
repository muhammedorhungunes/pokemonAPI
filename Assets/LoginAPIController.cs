using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginAPIController : MonoBehaviour
{
    public TMP_InputField TMP_InputField_Mail;
	public TMP_InputField TMP_InputField_Password;
	//public Button Login;
    private readonly string baseLoginURL = "https://www.kitapyurdu.com/index.php?route=mobile/login&app_id=33&version=5.9.1.8";
    // Start is called before the first frame update
    void Start()
    {
        
    }
	// Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonLogin()
    {    
	
	StartCoroutine(randomLogin( TMP_InputField_Mail.text , TMP_InputField_Password.text ));
    }
	IEnumerator randomLogin(string Mail,string Password)
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("field1=" + Mail + "&" + "field2=" + Password));
        //formData.Add(new MultipartFormFileSection("my file data", "myfile.txt"));

        UnityWebRequest www = UnityWebRequest.Post( baseLoginURL, formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
		JSONNode loginInfo = JSON.Parse(www.downloadHandler.text);
		bool loginSuccess = loginInfo["success"];
		if(loginSuccess == false){
			SceneManager.LoadScene("SampleScene");
		}else{
			Debug.Log("tekrar dene!");
		}
    }
    

}
