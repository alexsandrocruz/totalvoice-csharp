# totalvoice-csharp
Client C# para a API da TotalVoice

> ### Funcionalidades

- [X] Gerenciamento das chamadas
- [X] Consulta e envio de SMS
- [X] Consulta e envio de TTS
- [X] Consulta e envio de Audio
- [X] Gerenciamento da Conta
- [X] Gerenciamento de Ramais
- [X] URL do Webphone
- [X] Gerenciamento de DID

> ### Pré requisitos

- .NET Framework 4.6.1 ou .NET Core 2.0
- Nuget

> ### Utilização

Para utilizar esta biblioteca, primeiramente você deverá realizar um cadastro no site da [Total Voice](http://www.totalvoice.com.br).
Após a criação do cadastro será disponibilizado um AccessToken para acesso a API.

Com o AccessToken em mãos será possível realizar as consultas/cadastros conforme documentação da [API](https://api.totalvoice.com.br/doc/#/)

> #### Instalando com o gerenciador de pacotes [Nuget](https://www.nuget.org/packages/TotalVoice/) 

```
PM> Install-Package TotalVoice -Version 1.0.1
```
ou .NET CLI

```
dotnet add package TotalVoice --version 1.0.1
```

A seguir alguns exemplos de como pode ser utilizada esta biblioteca.

> ##### Realizar uma chamada telefônica entre dois números: A e B

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Chamada chamada = new Chamada(client);
            var json = new {
                numero_origem  = "48988888888",
                numero_destino = "48999999999"
            };
            string response = chamada.Ligar(json);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Consulta de chamada pelo ID

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Chamada chamada = new Chamada(client);
            string response = chamada.Buscar(123);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Enviar um SMS

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Sms sms = new Sms(client);
            var json = new {
                numero_destino = "48999999999",
                mensagem = "Mensagem de teste"
            };
            string response = sms.Enviar(json);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Buscar os dados de um SMS pelo ID

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Sms sms = new Sms(client);
            string response = sms.Buscar(123);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Enviar um TTS

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Tts tts = new Tts(client);
            var json = new {
                numero_destino = "48999999999",
                mensagem = "Mensagem de TTS"
            };
            string response = tts.Enviar(json);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Validacao de Numero

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            ValidaNumero validacao = new ValidaNumero(client);
            var json = new {
                numero_destino = "48999999999",
                gravar_audio   = true,
                bina           = "48808880804",
                max_tentativas = 1
            };
            string response = validacao.Enviar(json);
            System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ##### Enviar um Composto

```csharp
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            TotalVoiceClient client = new TotalVoiceClient("access-token");
            Composto composto = new Composto(client);
            var json = new {
              numero_destino = "48988888888",
              dados = new[] {
                 new {
                   acao = "tts",
                   acao_dados = new {
                     mensagem = "O número digitado não consta em nosso cadastro. Por gentileza, tente novamente",
                     tipo_voz = "br-Ricardo" 
                   }
                 },
                 new {
                   acao = "audio",
                   acao_dados = new {
                     url_audio = "https://minhaurl.com.br/audio.mp3"
                   }
                 }
              },
              gravar_audio     = false,
              bina             = "48988888888",
              tags             = "clienteX",
              detecta_caixa    = false
           };
           string response = composto.Enviar(json);
           System.Diagnostics.Debug.WriteLine(response);
        }
    }
}
```

> ### Licença

Esta biblioteca segue os termos de uso da [MIT](https://github.com/totalvoice/totalvoice-csharp/blob/master/LICENSE)
