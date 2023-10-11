# Plano de Testes de Software

**Introdução:**
Este plano de testes tem como objetivo garantir que o Sistema de Automação de Geração de Recibos de Cobrança atenda aos requisitos definidos na seção "2 - Especificação do Projeto". Os testes serão conduzidos para verificar a funcionalidade e confiabilidade do sistema, assegurando que ele atenda às necessidades dos cobradores e clientes.

<br>

**Cenários de Testes:**

<br>

| **Caso de Teste** 	| **CT-01 – Cadastro de Layout** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-001 - Criar uma interface amigável para que os cobradores possam cadastrar layouts personalizados. |
| Objetivo do Teste 	| Verificar se o sistema permite o cadastro de um novo layout de forma correta. |
| Passos 	| - Acessar o sistema. <br> - Navegar até a seção de cadastro de layouts. <br> - Preencher os campos obrigatórios para criar um novo layout. <br> - Clicar em "Salvar". |
| Critério de Êxito | O novo layout é cadastrado com sucesso no sistema. |

<br>

| **Caso de Teste** 	| **CT-02 – Armazenamento de Informações de Clientes e Datas de Pagamento** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-002 - Desenvolver um mecanismo de armazenamento de informações dos clientes e datas de pagamento. |
| Objetivo do Teste 	| Verificar se o sistema armazena corretamente as informações dos clientes e datas de pagamento. |
| Passos 	| - Cadastrar um novo cliente no sistema. <br> - Associar datas de pagamento a esse cliente. <br> - Verificar se as informações estão corretamente armazenadas. |
| Critério de Êxito | As informações do cliente e datas de pagamento estão armazenadas e associadas corretamente no sistema. |

<br>

| **Caso de Teste** 	| **CT-03 – Geração Automática de Recibos** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-003 - Implementar um algoritmo de geração automática de recibos com base nos layouts cadastrados. |
| Objetivo do Teste 	| Verificar se o sistema gera automaticamente recibos com base nos layouts cadastrados. |
| Passos 	| - Selecionar um layout previamente cadastrado. <br> - Escolher um cliente e uma data de pagamento. <br> - Iniciar o processo de geração de recibos. <br> - Verificar se o sistema gera os recibos conforme o layout e as informações fornecidas. |
| Critério de Êxito | Os recibos são gerados automaticamente de acordo com o layout e as informações fornecidas. |

<br>

| **Caso de Teste** 	| **CT-04 – Precisão dos Dados nos Recibos** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-004 - Assegurar a precisão dos dados em todos os recibos gerados pelo sistema. |
| Objetivo do Teste 	| Verificar se os dados nos recibos gerados são precisos e correspondem às informações cadastradas. |
| Passos 	| - Gerar um recibo usando o sistema. <br> - Comparar os dados no recibo com as informações cadastradas. |
| Critério de Êxito | Os dados no recibo são precisos e correspondem às informações cadastradas. |

<br>

| **Caso de Teste** 	| **CT-05 – Adaptação a Diferentes Requisitos de Cobrança** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-005 - Garantir que o sistema seja capaz de se adaptar a diferentes requisitos de cobrança. |
| Objetivo do Teste 	| Verificar se o sistema permite a personalização de layouts para diferentes requisitos de cobrança. |
| Passos 	| - Criar um novo layout personalizado para requisitos específicos. <br> - Gerar um recibo usando o novo layout. <br> - Verificar se o recibo atende aos requisitos especificados. |
| Critério de Êxito | O sistema permite a personalização de layouts e o recibo gerado atende aos requisitos especificados. |

<br>

| **Caso de Teste** 	| **CT-06 – Visualização e Revisão de Recibos** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-006 - Facilitar a visualização e revisão dos recibos antes de serem emitidos aos clientes. |
| Objetivo do Teste 	| Verificar se o sistema permite a visualização e revisão de recibos antes da emissão. |
| Passos 	| - Gerar um recibo no sistema. <br> - Visualizar o recibo antes de confirmar a emissão. <br> - Verificar se é possível realizar revisões, se necessário. |
| Critério de Êxito | O sistema permite a visualização e revisão dos recibos antes da emissão. |

<br>

 
**Conclusão:**
Este plano de testes abrange os cenários necessários para validar a funcionalidade do Sistema de Automação de Geração de Recibos de Cobrança. A execução desses testes ajudará a garantir que o sistema atenda aos objetivos e requisitos definidos, proporcionando eficiência, precisão e satisfação aos usuários.
