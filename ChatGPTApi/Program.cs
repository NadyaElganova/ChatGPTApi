// See https://aka.ms/new-console-template for more information
using ChatGPTApi;
using System.Net.Http.Headers;
using System.Net.Http.Json;

string requestUser = "";
Console.WriteLine("Начните свое общение с Ассистентом! Введите Ваш Вопрос или нажмите 0 для выхода из программы: ");
while (true)
{
    requestUser = Convert.ToString(Console.ReadLine());
    if (requestUser != "0")
    {
        ChatGptClient chatGptClient = new ChatGptClient(requestUser) { };
        Console.WriteLine(await chatGptClient.GetChatGptResponse());
        requestUser = "";
    }
    else
    {
        break;    
    }
}
Environment.Exit(0);