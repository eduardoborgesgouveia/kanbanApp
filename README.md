# kanbanApp

<p> Projeto desenvolvido como parte do processo seletivo para professor na Let's Code. </p>
<p> O projeto consiste em um backend em C# + ASP.NET Core + WebApi para o frontend disponibilizado pela equipe da Let's Code juntamente com as regras do desafio no link abaixo:</p>
Backend: https://gitlab.com/gabriel.militello1/desafio-tecnico-backend.git

# Rodando a aplicação

A aplicação desenvolvida conta com um sistema de login e autorização de acesso baseada em JWT.
<p> O corpo da requisção para realizar o login deve conter "login" e "senha", conforme especificação abaixo:</p>

```javascript
{ 
 "login": "COLOCAR_USUARIO",
 "senha": "COLOCAR_SENHA"
}
```

<p> Para realizar requisições primeiramente deve-se configurar a chave JWT e o usuário de acesso através do arquivo appsettings.json.</p>
<p> Abra o arquivo appsetting.json e substitua o campo "JWT:key" pela sua chave JWT e subsitua "credentials:user" e "credentials:password" por um usuário e senha que você desejar (esse usuário será utilizado no momento do login). </p>

```javascript
{
  "JWT": {
    "Key": "COLOCAR_CHAVE_JWT"
  },
  "credentials": {
    "user": "COLOCAR_USUARIO",
    "password": "COLOCAR_SENHA"
  }
}
```

<p> Uma vez que esses parâmetros foram configurados é possível rodar a aplicação através da execução do comando abaixo via linha de comando na pasta raiz da aplicação:</p>

```console
> dotnet run --project ./KanbanApp/KanbanApp.csproj

```
# Realizando o login
<p> Para realizar o login e receber o token de acesso aos demais endpoints o usuário deve realizar uma requisição POST para http://localhost:5000/login com o corpo da requisição descrito no tópico anterior. </p>

```
(POST)      http://localhost:5000/login/
```

<p> Uma vez que o login tenha sido realizado com sucesso o usuário poderá utilizar o token para acessar o CRUD de Cards através dos endereços abaixo: </p>

```
(GET)       http://localhost:5000/cards/
(POST)      http://localhost:5000/cards/
(PUT)       http://localhost:5000/cards/{id}
(DELETE)    http://localhost:5000/cards/{id}
```

<p></p>
<p></p>
