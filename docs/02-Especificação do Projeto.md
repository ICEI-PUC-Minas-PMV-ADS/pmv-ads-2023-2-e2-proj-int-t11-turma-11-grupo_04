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

**Hobbies:** Nos finais de semana, Carla gosta de praticar esportes ao ar livre, como corrida e trilhas. Ela também é uma leitora ávida e costuma passar horas imersa em livros.

**Motivações:** Carla está determinada a executar seu trabalho de forma eficiente e precisa. Ela valoriza a organização e busca maneiras de otimizar suas tarefas diárias para que possa dedicar mais tempo a outras atividades.

**Frustrações:** Ela se sente frustrada por gastar muito tempo preenchendo manualmente os recibos de cobrança todos os meses. Isso a impede de lidar com outras tarefas mais estratégicas e interessantes em seu trabalho. 

## Rafael Iago Novaes

<img src="../docs/img/persona_rafael.jpg" width="300px">

## Profissão: Gestor de setor fiscal

### Idade 35 anos
Rafael possui uma vasta experiência em gestão de equipes e assumiu o cargo de Gestor de setor fiscal recentemente. Ele busca maneiras de modernizar e otimizar as operações do departamento, tornando-as mais eficientes e precisas. 

**Hobbies:** Nas horas vagas, Rafael gosta de praticar esportes coletivos, como futebol, para relaxar e manter-se ativo. Ele também é um entusiasta de tecnologia e sempre está interessado em soluções que possam melhorar processos.

**Motivações:** Rafael está focado em garantir que a equipe de cobradores execute seu trabalho de maneira eficiente e precisa. Ele valoriza a conformidade e a qualidade no processo de cobrança para manter a reputação da empresa. 

**Frustrações:** Ele se preocupa com a possibilidade de erros nos recibos de cobrança e com a falta de uniformidade nas informações. Além disso, ele sente que a equipe de cobradores poderia ser mais produtiva se não fosse pela tarefa manual repetitiva. 


## Isabela Sara Caldeira

<img src="../docs/img/persona_isabela.jpg" width="300px">

## Profissão: Analista de Finanças de uma Instituição de Caridade

### Idade: 30 anos
Isabela estudou finanças e sempre quis usar suas habilidades para fazer a diferença. Ela se juntou à instituição de caridade como estagiária e, ao longo dos anos, progrediu para o cargo de Analista de Finanças. Seu objetivo é garantir que cada centavo arrecadado seja investido de maneira responsável e impactante. 

**Hobbies:** Isabela encontra diversas maneiras de equilibrar sua vida ocupada como Analista de Finanças em uma Instituição de Caridade. Ela pinta paisagens vibrantes em óleo para liberar sua criatividade e se desconectar das análises financeiras. Além disso, sua paixão por animais a leva a dedicar seu tempo livre a abrigos locais, onde sua ligação profunda com os animais necessitados a impulsiona a fazer uma diferença tangível. Participar de um clube do livro também é uma fuga bem-vinda para Isabela, permitindo que mergulhe em discussões intelectuais e explore diversos gêneros literários.

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
|RF-001| O sistema deve ter uma interface de usuário intuitiva e amigável. | ALTA |
|RF-002| O sistema deve permitir aos cobradores criar e salvar layouts personalizados para os recibos| ALTA | 
|RF-003| Os cobradores devem ser capazes de inserir os dados do cliente e a data de pagamento no layout   | ALTA |
|RF-004| O sistema deve ser capaz de gerar automaticamente os recibos com base nos layouts cadastrados.| ALTA|
|RF-005| Deve haver uma opção para visualizar e editar os layouts e recibos gerados.| ALTA |
 

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para proporcionar a melhor experiência ao usuário em qualquer dispositivo. | ALTA | 
|RNF-002| O sistema deve ter um tempo de resposta rápido ao gerar os recibos. |  ALTA |
|RNF-003| A segurança dos dados do cliente deve ser uma prioridade, protegendo informações sensíveis.| ALTA |

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| A equipe não pode subcontratar o desenvolvimento do trabalho, devendo ser desenvolvido apenas pelo grupo de alunos|
|03| O projeto deve ser publicado no GitHub |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
