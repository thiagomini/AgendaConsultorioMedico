## **Instruções de instalação:** ##

**1**. Configure o arquivo .env para apontar para o servidor sql server desejado (localhost preferencialmente) e as credenciais

**2**. utiliza o comando dotnet ef database update

**3**. caso o comando acima dê erro 'A network-related or instance-specific error occurred while establishing a connection to SQL Server'  (Error Number:10061,State:0,Class:20)
habilite as conexões TCP/IP ao banco, seguindo os passos adiante:

	3.1 Abra o programa SQL SERVER (versão) Configuration Manager

	3.2 procure na aba esquerda o item 'Configurações de Rede do SQL SERVER

	3.3 clique duas vezes no item Protocolos para MSSQLSERVER que aparecerá na aba direita

	3.4 clique duas vezes no ícone de TCP/IP que aparecerá

	3.5 Verifique se a opção 'Habilitado' está marcada como verdadeira

	3.6 Execute o comando do passo 2 novamente
	
4. Inicie o projeto com dotnet run.

**Autor**: Thiago Ribeiro Valentim MartinsC