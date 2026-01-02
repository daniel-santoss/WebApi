<h2>1. Tecnologias e Dependências</h2>
O projeto utiliza as seguintes bibliotecas e ferramentas:

- Framework: .NET 8.0.

- Entity Framework Core (v8.0.11): Para a persistência de dados e mapeamento objeto-relacional.

- Pomelo.EntityFrameworkCore.MySql (v8.0.2): Provider para integração com MySQL.

- Swashbuckle.AspNetCore (v6.8.1): Implementação do Swagger para documentação e testes da API.

<h2>2. Configuração da Base de Dados.</h2>A ligação à base de dados é definida no ficheiro appsettings.json através da string de conexão AppDbConnectionString:

- Servidor: localhost.

- Base de Dados: DBZ.

- Utilizador: root.

- Parâmetros Adicionais: SslMode=None.

- A configuração no Program.cs utiliza o método UseMySql com deteção automática da versão do servidor para inicializar o AppDbContext.

<h2>3. Modelo de Dados</h2>
O núcleo da aplicação é a classe Personagem, que define as propriedades e regras de validação:

- Id: Identificador único (Chave Primária).

- Nome: Campo obrigatório com o máximo de 50 caracteres.

- Tipo: Campo obrigatório com o máximo de 50 caracteres.

<h2>4. Endpoints da API (PersonagensController)</h2>
Todos os endpoints estão acessíveis através da rota base api/Personagens. Operações CRUD:

- Listar Todos (GET): GET /api/Personagens: Retorna a lista de todos os personagens registados na tabela DBZ.

- Obter por ID (GET): GET /api/Personagens/{id}: Procura um personagem específico. Retorna "Personagem não encontrado" (404) caso não exista.

- Adicionar (POST): POST /api/Personagens: Recebe um objeto Personagem no corpo da requisição. Valida o estado do modelo antes de guardar e retorna o status 201 (Created) em caso de sucesso.

- Atualizar (PUT): PUT /api/Personagens/{id}: Atualiza os valores de um personagem existente com base no ID fornecido.

- Eliminar (DELETE): DELETE /api/Personagens/{id}: Remove o registo do personagem da base de dados e confirma a exclusão com uma mensagem de sucesso.

<h2>5. Funcionalidades de Desenvolvimento</h2>
Swagger/OpenAPI: Em ambiente de desenvolvimento, a API disponibiliza uma interface visual (Swagger UI) para exploração e teste dos endpoints.

- Segurança: O pipeline inclui suporte para redirecionamento HTTPS e middleware de autorização (UseAuthorization).

- Injeção de Dependências: O contexto da base de dados (AppDbContext) é injetado diretamente no controlador para facilitar a manutenção e testes.
