# Registro de Testes de Software

<br>

| **Caso de Teste** 	| **CT-01 – Cadastro de Cobrador** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-001 - O sistema deve permitir o cobrador fazer cadastro no sistema. |
| Objetivo do Teste 	| Verificar se o sistema cadastra corretamente as informações dos cobradores. |
| Passos 	| - Preencher os dados do novo cobrador na parte de cadastro. <br> - Clicar em "criar conta". <br> - Verificar se as informações estão corretamente armazenadas. |
| Critério de Êxito | Aparece imagem de sucesso e as informações do cobrador estão armazenadas corretamente no sistema. |
<br>

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t11-turma-11-grupo_04/assets/128761321/9c0ece06-7073-42ab-96c3-ee4121f9de36

O vídeo acima evidencia o cadastro de um cobrador no sistema e segue os seguintes critérios:
  1. O campo de Nome deve permitir apenas caracteres alfabéticos, incluindo acentos do alfabeto da língua portuguesa (pt-br).
  2. O campo de Email deve permitir somente formato de Email válido.
  3. O campo CPF deve permitir somente números e exatos 11 dígitos e ao digitar o 11° número o sistema deve formatar para xxx.xxx.xxx-xx bloqueando a digitação de demais dígitos.
  4. O campo Telefone deve permitir somente números e exatos 10 dígitos e o sistema deve formatar para (xx)xxxx-xxxx bloqueando a digitação de demais dígitos.
  5. Ao inserir a senha nos campos Senha e Confirmar Senha, esses devem estar ocultos para visualização por questões de segurança.
  6. Os campos Senha e Confirmar Senha devem ter valores iguais.

Dentre os passos descritos no Caso de Teste, foram verificados com êxito:<br>
  1. **Cadastrar um novo cobrador no sistema.**<br>
  2. **Verificar se as informações estão corretamente armazenadas.**
<br>

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t11-turma-11-grupo_04/assets/104398945/95cc43b3-e953-4277-a798-1e48f5ea1995)

<br>

| **Caso de Teste** 	| **CT-02 – Armazenamento de Informações de Clientes e Datas de Pagamento** 	|
|:---:	|:---:	|
| Requisito Associado 	| RF-002 - Desenvolver um mecanismo de armazenamento de informações dos clientes e datas de pagamento. |
| Objetivo do Teste 	| Verificar se o sistema armazena corretamente as informações dos clientes e datas de pagamento. |
| Passos 	| - Cadastrar um novo cliente no sistema. <br> - Associar datas de pagamento a esse cliente. <br> - Verificar se as informações estão corretamente armazenadas. |
| Critério de Êxito | As informações do cliente e datas de pagamento estão armazenadas e associadas corretamente no sistema. |
<br>

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t11-turma-11-grupo_04/assets/128761321/9c0ece06-7073-42ab-96c3-ee4121f9de36

O vídeo acima evidencia o cadastro de um cliente no sistema e segue os seguintes critérios:
  1. O campo de Nome deve permitir apenas caracteres alfabéticos, incluindo acentos do alfabeto da língua portuguesa (pt-br).
  2. O campo de Email deve permitir somente formato de Email válido.
  3. O campo CPF deve permitir somente números e exatos 11 dígitos e ao digitar o 11° número o sistema deve formatar para xxx.xxx.xxx-xx bloqueando a digitação de demais dígitos.
  4. O campo Telefone deve permitir somente números e exatos 10 dígitos e o sistema deve formatar para (xx)xxxx-xxxx bloqueando a digitação de demais dígitos.

Dentre os passos descritos no Caso de Teste, foram verificados com êxito:<br>
  1. **Cadastrar um novo cliente no sistema.**<br>
  2. Associar datas de pagamento a esse cliente.<br>
  3. **Verificar se as informações estão corretamente armazenadas.**

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-2-e2-proj-int-t11-turma-11-grupo_04/assets/128761321/601d0b14-0bd4-40dd-a699-35cacb4df0ff)



  
<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.

> **Links Úteis**:
> - [Ferramentas de Test para Java Script](https://geekflare.com/javascript-unit-testing/)
