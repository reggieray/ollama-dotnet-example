
# Brief Intro

This repo is a quick getting started into using AI models with dotnet locally.

**What is Ollama?**

Ollama is an open-source tool that simplifies running large language models (LLMs) locally on your computer.


**What is llama3?**

Llama 3 is a series of powerful, open-source large language models (LLMs) developed and released by Meta AI.

# Prerequisites

Docker Desktop

# Getting started

The quickest and easiest way to get started is to use docker and pull Ollama.

`docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama ollama/ollama`

In this example I will pull the `llama3` model. You find more models available [here](https://ollama.com/library)


`docker exec -it ollama ollama run llama3`

Create a new console app to interact with `llama3` through `Ollama`.

`dotnet new console -n ollama.demo`

Add the `Ollama` dotnet library. You could also probably hand roll your own HttpClient, but in interest of time I'll use the NuGet package.  

`dotnet add package OllamaSharp --version 5.3.4`

Update `Program.cs` with the following:

```csharp
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
```

Run the application from the terminal 

`dotnet run --project .\ollama.demo\ollama.demo.csproj`



# Useful Links

https://github.com/ollama/ollama
https://hub.docker.com/r/ollama/ollama
https://ollama.com/search
https://github.com/awaescher/OllamaSharp