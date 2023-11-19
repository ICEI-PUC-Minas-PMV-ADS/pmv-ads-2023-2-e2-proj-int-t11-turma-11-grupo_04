# Programação de Funcionalidades

### Implementação

A implementação do sistema foi realizada de acordo com os requisitos funcionais e/ou não funcionais especificados na [Especificação do Projeto](/docs/2-Especificação%20do%20Projeto.md). Abaixo estão listados alguns dos requisitos atendidos juntamente com os artefatos produzidos.

### Requisitos Funcionais

| ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|-------|--------------------------|--------------------------|
| RF-001 | O sistema deve permitir o cobrador fazer cadastro no sistema | `create.shtml` / `Cobrador.cs` / `CobradoresController.cs` | 
| RF-002 | O sistema deve permitir exibir os dados do usuário em um perfil | - |
| RF-003 | O sistema deve permitir aos cobradores criar e salvar layouts personalizados para os recibos | `vwClientes/Create.cshtml` / `vwCobradores/Create.cshtml` |
| RF-004 | O sistema deve permitir o cobrador inserir clientes | `ClientesController.cs` / `vwClientes/Create.cshtml` |
| RF-005 | Os cobradores devem ser capazes de selecionar os dados do cliente e a data de pagamento no layout | `vwCobradores/Edit.cshtml` |
| RF-006 | O sistema deve ser capaz de gerar automaticamente e enviar os recibos com base nos layouts cadastrados | - |
| RF-007 | Deve haver uma opção para gerenciar os layouts e recibos gerados | - |

### Requisitos Não Funcionais

| ID    | Descrição do Requisito  | Artefato(s) produzido(s) |
|-------|--------------------------|--------------------------|
| RNF-001 | O sistema deve ser responsivo para proporcionar a melhor experiência ao usuário em qualquer dispositivo | Implementação de design responsivo nas páginas |
| RNF-002 | O sistema deve ter um tempo de resposta rápido ao gerar os recibos | Otimizações na lógica de geração de recibos |
| RNF-003 | A segurança dos dados do cliente deve ser uma prioridade, protegendo informações sensíveis | Implementação de medidas de segurança, como HTTPS e criptografia |
| RF-004 | O sistema deve ter uma interface de usuário intuitiva e amigável | Implementação de design amigável nas páginas |

## Instruções de Acesso

Para acessar e verificar a implementação, siga as instruções abaixo:

1. **Ambiente de Hospedagem:**
   - O sistema está atualmente hospedado no ambiente de desenvolvimento.

2. **Acesso ao Sistema:**
   - Abra um navegador da web e acesse:

3. **Verificação de Funcionalidades:**
   - Utilize as seguintes funcionalidades para verificar a implementação:
     - Cadastro de Cobrador: Navegue até a página de cadastro e preencha as informações necessárias.
     - Cadastro de Cliente: Acesse a página de cadastro de clientes e insira os detalhes conforme necessário.
     - Criação de Layout de Recibo: Utilize as páginas de criação de layouts para criar layouts personalizados.

4. **Perfil do Usuário:**
   - Para verificar o perfil do usuário, aguarde a implementação completa dessa funcionalidade.

Essas são instruções básicas para acessar e verificar a implementação. Certifique-se de que o ambiente de hospedagem esteja configurado corretamente para evitar problemas de acesso.
