using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start_Scene : MonoBehaviour {

    //public Button button;
    //public Canvas canvasToDisable;

    void Start()
    {
/*        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);*/
    }

/*    void OnButtonClick()
    {
        SceneManager.LoadScene("LabScene");
    }*/

    private void OnTriggerEnter(Collider collision)
    {
        //canvasToDisable.gameObject.SetActive(false);
        SceneManager.LoadScene("Scene_Laboratory");
    }

}
