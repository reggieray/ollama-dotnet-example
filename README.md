
# 📃 Overview

This repo is a quick getting started into using AI models locally with dotnet.

By the end of this guide, you’ll have a .NET console app that sends prompts to Llama 3 via Ollama and receives responses in real time.

**🤖 What is Ollama?**

Ollama is an open-source runtime that makes it easy to run large language models (LLMs) locally on your machine. It handles model loading, execution, and exposes a simple API you can interact with from any language — including C#.
- GitHub: https://github.com/ollama/ollama
- Website: https://ollama.com

**🦙 What is Llama 3?**

Llama 3 is a family of powerful open-source LLMs released by Meta AI in 2024. It is designed to be fast, capable, and efficient to run even on consumer-grade hardware.

You can browse other available models here: https://ollama.com/library

# ⚙️ Prerequisites

* An installation of [Docker Desktop](https://www.docker.com/products/docker-desktop/) and assumption of how to run docker commands
* .NET 6 or later

# 🚀 Getting started

The quickest and easiest way to get started is to use docker and pull Ollama.

`docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama ollama/ollama`

In this example I will pull the `llama3` model. You can find more models available [here](https://ollama.com/library)


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

# 🔗 Useful Links

* https://github.com/ollama/ollama
* https://hub.docker.com/r/ollama/ollama
* https://ollama.com/search
* https://github.com/awaescher/OllamaSharp


