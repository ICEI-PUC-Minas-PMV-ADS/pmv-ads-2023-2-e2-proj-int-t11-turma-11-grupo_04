# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.

![d3d87ffb-241b-4042-b474-63eaada82656](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t11-turma-11-grupo_04/assets/128761321/ec572b2d-fdfe-4855-b311-eed2b7219d26)

## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.
<br>

![Diagrama_ER](img/Diagrama_entidade.jpg)

## Projeto da Base de Dados

Este projeto de base de dados tem como objetivo criar a estrutura de armazenamento de informações essenciais para a nossa aplicação. A base de dados será projetada para acomodar informações detalhadas sobre clientes e  cobranças e outros atributos relevantes. A estrutura de banco de dados será desenvolvida para garantir eficiência, escalabilidade e integridade dos dados, permitindo que a aplicação gerencie as operações necessárias de forma eficaz e segura.

Tabela **clientes**<br>
id_cliente (PK)<br>
Nome<br>
Sobrenome<br> 
Cidade<br>
CPF<br>
CEP<br>
Telefone <br>
Email<br>
<br>

Tabela **cobrador**<br>
id_cobrador (PK)<br>
Nome<br>
Sobrenome <br>
Cidade<br>
CPF<br>
CEP<br>
Telefone <br>
Email<br>
<br>

Tabela **Cobrança** <br>
id_cobranca (PK)<br>
id_cliente(FK)<br>
id_cobrador(FK)<br>
data<br>
vencimento<br>
valor<br>
status<br>

**Relacionamentos**:<br>
Um cobrador pode ter vários clientes, e um cliente pode ter vários cobradores. 
<br><br>
A Entidade cobrança surge com o relacionamento entre cliente e cobrador. Uma cobrança tem apenas um cobrador e apenas um cliente. 

## Tecnologias Utilizadas

As tecnologias que escolhemos utilizar para implementar a nossa solução são: 
<br>
- **Linguagens:** C#, JavaScript, HTML/CSS
- **Frameworks e/ou bibliotecas:** ASP.NET e Bootstrap
- **IDEs de desenvolvimento:** Visual Studio Code
- **Ferramentas:** Mysql
  
## Hospedagem

O site utiliza a plataforma do Github Pages como ambiente de hospedagem do site do projeto. 

A publicação do site no Github Pages é feita por meio de uma submissão do projeto (push) via git para o repositório que se encontra no endereço:https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e3-proj-mov-t3-EduSync
