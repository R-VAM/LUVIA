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
        api = new OpenAIAPI("API Key");
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
        //��ư Disable
        okBtn.enabled = false;

        //���� �޼����� inputField��
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = inputField.text;
        if (userMessage.Content.Length > 100)
        {
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0} : {1}", userMessage.Role, userMessage.Content));

        //list�� �޼��� �߰�
        messages.Add(userMessage);

        //textField�� userMessageǥ�� 
        textField.text = string.Format("You: {0}", userMessage.Content);

        // �߰�
        //Debug.Log(textField.text);

        //inputField �ʱ�ȭ
        inputField.text = "";

        // ��ü ä���� openAI �����������Ͽ� ���� �޽���(����)�� ����������
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1,
            MaxTokens = 150,
            Messages = messages
        });

        //���� ��������
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.Role, responseMessage.Content));

        //������ message����Ʈ�� �߰�
        messages.Add(responseMessage);

        //textField�� ���信 ���� Update
        textField.text = string.Format("You: {0}\n\nChatGPT:\n{1}", userMessage.Content, responseMessage.Content);

        //Okbtn�ٽ� Ȱ��ȭ
        okBtn.enabled = true;
    }

    public async void getResponseByText(string myText)
    {
        if (myText.Length < 1)
        {
            return;
        }
        //��ư Disable
        okBtn.enabled = false;

        //���� �޼����� inputField��
        ChatMessage userMessage = new ChatMessage();
        userMessage.Role = ChatMessageRole.User;
        userMessage.Content = myText;
        if (userMessage.Content.Length > 100)
        {
            userMessage.Content = userMessage.Content.Substring(0, 100);
        }
        Debug.Log(string.Format("{0} : {1}", userMessage.Role, userMessage.Content));

        //list�� �޼��� �߰�
        messages.Add(userMessage);

        //textField�� userMessageǥ�� 
        textField.text = string.Format("You: {0}", userMessage.Content);

        // �߰�
        //Debug.Log(textField.text);

        //inputField �ʱ�ȭ
        inputField.text = "";

        // ��ü ä���� openAI �����������Ͽ� ���� �޽���(����)�� ����������
        var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
        {
            Model = Model.ChatGPTTurbo,
            Temperature = 0.1,
            MaxTokens = 150,
            Messages = messages
        });

        //���� ��������
        ChatMessage responseMessage = new ChatMessage();
        responseMessage.Role = chatResult.Choices[0].Message.Role;
        responseMessage.Content = chatResult.Choices[0].Message.Content;
        Debug.Log(string.Format("{0}: {1}", responseMessage.Role, responseMessage.Content));

        //������ message����Ʈ�� �߰�
        messages.Add(responseMessage);

        //textField�� ���信 ���� Update
        textField.text = string.Format("You: {0}\n\nChatGPT:\n{1}", userMessage.Content, responseMessage.Content);

        //Okbtn�ٽ� Ȱ��ȭ
        okBtn.enabled = true;
    }
}
