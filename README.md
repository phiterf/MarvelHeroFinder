# Configuração

As chaves da api devem ser incluídas no arquivo **settings.conf**. O repositório conta com um arquivo **setings.conf.example**, que deve ser renomeado para **settings.conf**. Depois é só colocar as chaves da API da marvel nos devidos lugares.

# Banco de dados

A aplicação foi feita utilizando o LocalDB, porém pode ser adaptada para outros bancos de dados, caso necessário. Basta alterar a connection string no arquivo **web.config**.

Para gerar as tabelas, foi criada uma migration que cria a tabela de Busca, onde ficam salvas as pesquisas feitas através da API.
