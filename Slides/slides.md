---
theme: "night"
transition: "slide"
title: "Distributed Lock"
enableMenu: false
enableSearch: false
enableChalkboard: false
---

## Distributed Lock

![Distributed Lock](./images/capa.svg){width=40%}

---

#### Exemplo

![-](./images/fluxo.png){width=100%}

<img>

---

![-](./images/fluxo-detalhado.png){width=100%}

---

![-](./images/1-message.png){width=100%}

---

![-](./images/2-saldo.png){width=100%}

---

![-](./images/3-saldo.png){width=100%}

---

![-](./images/race.png){width=100%}

---

### Race Condition

![-](./images/race.svg){width=70%}

---

![-](./images/1-race.png){width=75%}

---

![-](./images/2-race.png){width=70%}

---

![-](./images/3-race.png){width=80%}

---

![-](./images/4-race.png){width=80%}

---

![-](./images/lost-update.png){width=58%}

---

### Como Resolver❓

---

### Lock

# 🔒

---

![-](./images/lock.png){width=50%}

---

![-](./images/lock-especifico.png){width=50%}

---

### Onde é feito Lock?

---

### Memória RAM

![-](./images/lock-csharp.png){width=100%}

---

### Mutex

![-](./images/mutex.png){width=80%}

---

### Escala horizontal

![-](./images/escala.png)

---

### Distributed Lock

##### DLM - Distributed Lock Manager

---

![-](./images/redis.png)

---

### Optimistic Locking

## vs

### Pessimistic Locking
