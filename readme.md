# API Crud Ações e Fiis

1 - API que consiste em fazer um cadastro de ativos da B3 que uma pessoa possui.
2 - Lista com as funcionalidades:

- [] Crud de Ações da B3
- [] Crud de Fiis da B3
- [] Valorização/Desvalorização do Ativo

## 🔧 Instalação
Depois de clonar o projeto, seguir os passos:

```
1 - Instalar a versão 5.0 do dotnet

2 - Instalar os pacotes do Entity Framework
    2.1 - Microsoft.EntityFrameworkCore.Sqlite v5.0.17
        2.1.1 - Para poder trabalhar com o entity framework
    2.2 - Microsoft.EntityFrameworkCore.Design v5.0.17
        2.2.1 - Para poder trabalhar com as migrações

3 - Rodar o comando para atualizar a base de dados de acordo com as migrações e criar o banco local
    3.1 - dotnet ef database update

4 - Caso tenha problema no passo 3, 
    4.1 - instalar versao global do ef
    4.2 - colocar no path de variaveis de ambiente o caminho do ef
    4.3 - testar dotnet ef → tem que aparecer um unicornio
    4.4 - repetir o passo 3

5 - Rodar o projeto
    5.1 - dotnet watch run
```

## 🛠️ Tecnologias 

* [.Net 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) 
* Atualizado para o [.NET 6.0]
* Entity Framework
