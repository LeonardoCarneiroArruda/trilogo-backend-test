	# Desafio Backend #


Antes de iniciar é necessário as seguintes informações: 
* A aplicação foi desenvolvida para trabalhar com um banco Postgres
* Todas as rotas foram testadas utlizando o aplicativo Postman

Para começar seu postgres ja deve possuir um banco com o nome que desejar. 
No arquivo CredentialsDBSingleton.cs informe as seguintes constantes para acessar o Banco de dados:

* _server: 127.0.0.1
* _database: trilogo
* _port: 7071
* _user: postgres
* _password: 123456



**Autenticação**

Foi implementado a tecnologia de autenticação JWT.
Significa que antes de iniciar os testes na aplicação é necessário se autenticar através da seguinte rota 

### POST `/api/login/` 

Passando no body da requisição um json no formato: 
{
    "login":"admin",
    "senha":"admin"
}

Todas as credenciais de acesso válidas estão no arquivo UsuarioRepository.cs.
O token retornado pela requisição citada acima, deve ser usado nas próximas requisições com autenticação no formato Bearer Token 
e será válido pelos próximos 2 minutoa, após isso é necessário obter um novo token de acesso e assim por diante.
