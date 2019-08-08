# Dinâmica de Desenho Dirigido por Domínios (DDD)  

**Pontifícia Universidade Católica de Minas Gerais**  
**Especialização:** Arquitetura de Software Distribuído  
**Disciplina:** Análise, Projeto e Avaliação Arquitetural  
**Professor:** Marco Mendes  

**Guias iniciais para as entidades Usuário (User), que representa o correntista, e produto (Product):**  
http://bit.ly/ddd-exercício  
http://bit.ly/2KboaWJ  

**Requisitos para a entidade Conta Corrente (CheckingAccount):**  

- O débito deve permitir sacar dinheiro até um valor que seja a soma do saldo e do limite de crédito na conta.  

- Operações de crédito acima de 50000 reais devem gerar uma notificação de movimentação para o COAF - por simplicidade, a notificação é simulada através de uma mensagem de log.  

- Um correntista deve ter um nome, CPF, telefone e endereço.

- Toda Conta Corrente pertence a um único Correntista. 

