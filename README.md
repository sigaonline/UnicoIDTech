# UnicoIDTech
# Funcionalidades desenvolvidas:
  1. Importaçao do arquivo DEINFO_AB_FEIRASLIVRES_2014.csv.
    - Importação esta sendo realizada no momento que o micro-serviço sobe.
  2. Endpoints desenvolvidos:
    - Post de uma nova feira;
    - Put de uma feira existente;
    - Get de todas as feiras;
    - Get por Id;
    - Get por nome;
    - Exclusão por Id.
  3. Testes Unitários:
    - Testes unitários mocados.
    - Para verifica o coverage utilizei o Fine Code Coverage, link para download: https://github.com/FortuneN/FineCodeCoverage/releases
    - Cobertura acima dos 90%
  
  4. Arquivo postman, Desafio.postman_collection.json,  com os payloads incluso, precisando apenas alterar os id quando for executar.
  
  Observações:
  - Deve-se ter instalado;
    - Docker
    - Visual Studio 2022
    - Fine Code Coverage https://github.com/FortuneN/FineCodeCoverage/releases
    - clonar o repositorio , codigo ma branch master.
    - Na primeira execução do micro-serviço em meu ambiente estava ocorrendo um erro ao acessar o banco de dados do MySQL, porem na segunda execução funciona mormalmente. Não tive tempo de verificar este bug. Acho que o docker esta demorando um pouco pra subir.
  
  
