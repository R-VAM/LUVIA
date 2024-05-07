using OpenAI_API.Chat;
using OpenAI_API.Models;
using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OpenAIController : MonoBehaviour
{
    public TMP_Text textField;
    public TMP_InputField inputField;
    public Button okBtn;

    private OpenAIAPI api;
    private List<ChatMessage> messages;

    void Start()
    {
        api = new OpenAIAPI("sk-proj-vgJNBKxDEaH1Vyr9UJ4ST3BlbkFJ9cnvkFVIlDn15x8pUZKy");
        StartConversation();
        okBtn.onClick.AddListener(() => GetResponse());
    }

    private void StartConversation()
    {
        messages = new List<ChatMessage>
        {
            new ChatMessage(ChatMessageRole.System, "HI")
        };

        inputField.text = "";
        string startString = "If you have any questions, please ask me.";
        textField.text = startString;
        Debug.Log(startString);
    }

    private async void GetResponse()
    {
        if (inputField.text.Length < 1)
        {
            return;
        }
        //버튼 Disable
        okBtn.enabled = false;

        //유저 메세지에 inputField를
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0} : {1}", userMessage.Role, userMessage.Content));

        //list에 메세지 추가
        messages.Add(userMessage);

        //textField에 userMessage표시 
        textField.text = string.Format("You: {0}", userMessage.Content);

        // 추가
        //Debug.Log(textField.text);

        //inputField 초기화
        inputField.text = "";

        // 전체 채팅을 openAI 서버에전송하여 다음 메시지(응답)를 가져오도록
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1,
            MaxTokens = 150,
            Messages = messages
        });

        //응답 가져오기
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.Role, responseMessage.Content));

        //응답을 message리스트에 추가
        messages.Add(responseMessage);

        //textField를 응답에 따라 Update
        textField.text = string.Format("You: {0}\n\nChatGPT:\n{1}", userMessage.Content, responseMessage.Content);

        //Okbtn다시 활성화
        okBtn.enabled = true;
    }

    public async void getResponseByText(string myText)
    {
        if (myText.Length < 1)
        {
            return;
        }
        //버튼 Disable
        okBtn.enabled = false;

        //유저 메세지에 inputField를
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = myText;
        if (userMessage.Content.Length > 100)
        {
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0} : {1}", userMessage.Role, userMessage.Content));

        //list에 메세지 추가
        messages.Add(userMessage);

        //textField에 userMessage표시 
        textField.text = string.Format("You: {0}", userMessage.Content);

        // 추가
        //Debug.Log(textField.text);

        //inputField 초기화
        inputField.text = "";

        // 전체 채팅을 openAI 서버에전송하여 다음 메시지(응답)를 가져오도록
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1,
            MaxTokens = 150,
            Messages = messages
        });

        //응답 가져오기
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.Role, responseMessage.Content));

        //응답을 message리스트에 추가
        messages.Add(responseMessage);

        //textField를 응답에 따라 Update
        textField.text = string.Format("You: {0}\n\nChatGPT:\n{1}", userMessage.Content, responseMessage.Content);

        //Okbtn다시 활성화
        okBtn.enabled = true;
    }
}
