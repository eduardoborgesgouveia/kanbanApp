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
> dotnet run --project ./BACK/KanbanApp.csproj

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
# Considerações Finais
<p> O projeto pedia para criar o backend e colocar na pasta "BACK" assumindo que a outra pasta seria o "FRONT" disponibilizado pela equipe da Let's Code.</p>
<p> Entretanto, ao rodar o Front na minha máquina eu fui incapaz de faze-lo funcionar em tempo de desafio. O objeto cards apresentava um erro. Tentei contorna-lo colocando uma trativa conforme o código abaixo. Porém, o erro persistiu em outras etapas do código do FRONT e a falta de tempo hábil me impediu de resolver.</p>

```javascript
{ cards ? 
  cards.filter(c => c.lista === 'ToDo').map(c =>
      <Card
          key={c.id}
          titulo={c.titulo}
          conteudo={c.conteudo}
          sendForward={changeListHandler('Doing', c.id)}
          update={updateCardHandler(c.id)}
          remove={removeCardHandler(c.id)}
      />
  ) : <p>Sem cards</p>
}
```
<p> Entretanto, disponibilizo o acesso ao meu POSTMAN https://go.postman.co/workspace/My-Workspace~c9cf4b09-b583-4a08-831c-ed4cd938c525/collection/4126600-f8f7353f-0da0-4f5b-b4e6-397b7c5246a7?action=share&creator=4126600</p>
