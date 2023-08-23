# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

## Carla Jaqueline da Rocha 
<img src="../docs/img/persona_carla.jpg" width="300px">

## Profissão: Cobradora de empresa de pequeno porte 

### Idade: 26 anos
Carla começou como assistente administrativa na empresa e, ao longo do tempo, assumiu a responsabilidade de cuidar das cobranças. Ela é uma pessoa comprometida e quer oferecer um serviço de alta qualidade aos clientes, mas a tarefa repetitiva de preencher recibos tem sido um obstáculo. 

**Motivações:** Carla está determinada a executar seu trabalho de forma eficiente e precisa. Ela valoriza a organização e busca maneiras de otimizar suas tarefas diárias para que possa dedicar mais tempo a outras atividades.

**Frustrações:** Ela se sente frustrada por gastar muito tempo preenchendo manualmente os recibos de cobrança todos os meses. Isso a impede de lidar com outras tarefas mais estratégicas e interessantes em seu trabalho. 

## Rafael Iago Novaes

<img src="../docs/img/persona_rafael.jpg" width="300px">

## Profissão: Gestor de setor fiscal

### Idade 35 anos
Rafael possui uma vasta experiência em gestão de equipes e assumiu o cargo de Gestor de setor fiscal recentemente. Ele busca maneiras de modernizar e otimizar as operações do departamento, tornando-as mais eficientes e precisas. 

**Motivações:** Rafael está focado em garantir que a equipe de cobradores execute seu trabalho de maneira eficiente e precisa. Ele valoriza a conformidade e a qualidade no processo de cobrança para manter a reputação da empresa. 

**Frustrações:** Ele se preocupa com a possibilidade de erros nos recibos de cobrança e com a falta de uniformidade nas informações. Além disso, ele sente que a equipe de cobradores poderia ser mais produtiva se não fosse pela tarefa manual repetitiva. 


## Isabela Sara Caldeira

<img src="../docs/img/persona_isabela.jpg" width="300px">

## Profissão: Analista de Finanças de uma Instituição de Caridade

### Idade: 30 anos
Isabela estudou finanças e sempre quis usar suas habilidades para fazer a diferença. Ela se juntou à instituição de caridade como estagiária e, ao longo dos anos, progrediu para o cargo de Analista de Finanças. Seu objetivo é garantir que cada centavo arrecadado seja investido de maneira responsável e impactante. 

**Motivações:** Isabela é apaixonada por ajudar os outros e acredita no poder das instituições de caridade para criar um impacto positivo na sociedade. Ela se dedica a analisar os dados financeiros da organização para garantir que os recursos sejam utilizados de forma eficaz em projetos humanitários. 

**Frustrações:** Isabela enfrenta frustrações ao lidar com a geração manual de recibos de doações e serviços prestados pela instituição de caridade. Ela acredita que o processo atual é demorado e propenso a erros, o que afeta a transparência e a confiabilidade das informações financeiras. Além disso, a tarefa de rastrear e documentar cada transação individualmente consome muito do seu tempo, reduzindo a capacidade de se concentrar em análises mais estratégicas para maximizar o impacto dos recursos. 


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Usuário do sistema  | Cadastrar diferentes recibos de cobrança    | Aumentar a praticidade na cobrança dos clientes|
|Usuário do sistema | Criar automaticamente recibos para os futuros meses                 | Não precisar preencher os mesmo todos os meses |
|Usuário do sistema | Que o sistema envie por e-mail os recibos | Para não precisar realizar esse processo todos os meses|
|Usuário do sistema| Realizar a impressão dos documentos | Caso a cobrança precise ser feita fisicamente|

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o usuário cadastre tarefas | ALTA | 
|RF-002| Emitir um relatório de tarefas no mês   | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA | 
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
