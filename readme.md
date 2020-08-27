## **Instruções de instalação:** ##

**1**. Configure o arquivo .env para apontar para o servidor sql server desejado (localhost preferencialmente) e as credenciais

**2**. utiliza o comando dotnet ef database update

**3**. caso o comando acima dê erro 'A network-related or instance-specific error occurred while establishing a connection to SQL Server'  (Error Number:10061,State:0,Class:20)
habilite as conexões TCP/IP ao banco, seguindo os passos adiante:
	__3.1__ Abra o programa SQL SERVER (versão) Configuration Manager

	__3.2__ procure na aba esquerda o item 'Configurações de Rede do SQL SERVER

	__3.3__ clique duas vezes no item Protocolos para MSSQLSERVER que aparecerá na aba direita

	__3.4__ clique duas vezes no ícone de TCP/IP que aparecerá

	__3.5__ Verifique se a opção 'Habilitado' está marcada como verdadeira

	__3.6__ Execute o comando do passo 2 novamente
	
4. Inicie o projeto com dotnet run.

**Autor**: Thiago Ribeiro Valentim Martins