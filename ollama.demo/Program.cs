using OllamaSharp;

var uri = new Uri("http://localhost:11434");
var ollama = new OllamaApiClient(uri)
{
    SelectedModel = "llama3"
};

var chat = new Chat(ollama);

while (true)
{
    var message = Console.ReadLine();
    await foreach (var answerToken in chat.SendAsync(message!))
        Console.Write(answerToken);
}