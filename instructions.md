# Rodar aplicação com Docker
1. Na pasta raíz do repositório, editar arquivo **.env** e configurar em qual **porta** você quer expôr a aplicação. É importante escolher uma porta que já não esteja alocada em sua máquina.
3.  Na pasta raiz do repositório, executar o seguinte comando:
```bash
docker-compose up -d
```
4. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:
```bash
The server is healthy, up and running 🚀
```
5. Acessar o endpoint do SwaggerUI **"GET http /swagger/index.html"**.

# Rodar aplicação com .NET 5
1. Buildar o projeto.
```bash
dotnet build -c Release -o output
```

2. Executar o projeto. O projeto será iniciado nas portas **5000 (http)** e **5001 (https)**.
```bash
dotnet .\output\MercadoEletronico.Challenge.dll
```
3. Testar endpoint **"GET http /api/healthcheck"** que deverá retornar a seguinte mensagem:
```bash
The server is healthy, up and running 🚀
```
4. Acessar no navegador o endpoint do SwaggerUI **"GET http /swagger/index.html"**.