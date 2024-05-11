using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatGPT : MonoBehaviour
{
    public TMP_Text tmp;
    public OpenAIController openAIController;

    public void getText(string nText)
    {
        tmp.text = nText;
        openAIController.getResponseByText(nText);
    }
}
