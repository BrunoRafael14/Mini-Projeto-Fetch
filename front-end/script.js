// // POST
// const botaoEnvio = document.querySelector("#botaoEnvio");
// const url = "http://localhost:5290/api/Pessoas";


// // GET

// const botaoBuscaUsuario = document.querySelector("#botaoBuscaUsuario");

// botaoBuscaUsuario.onclick = async function (event) {
//     event.preventDefault();

//     let nome = document.querySelector("#nomeBusca").value;
    
//     const resposta_usuarios = await fetch(url);
//     const usuarios = await resposta_usuario.json();

//     usuarios.array.forEach(usuario => {
//         if(nome in usuario.Nome){
//             console.log(usuario);
//         }
//         else{
//             console.log("Não há nenhum usurio com esse nome")
//         }
//     });

    
    
// }


// // POST

// const botaoEnviarUsuarios = document.querySelector("#botaoEnvio");

// botaoEnviarUsuarios.onclick = async function (event) {
//     event.preventDefault();

//     const nome = document.querySelector("#nomeEnvio").value;
//     const email = document.querySelector("#emailEnvio").value;

//     const resposta_chamada = await fetch(url, {
//         method: "POST",
//         headers: {
//             "Content-Type": "application/json"
//         },
//         body: JSON.stringify({
//             nome: nome,
//             email: email
//         })
//     });
//     const resposta = await resposta_chamada.json(); //mesma coisa, porem o json automaticamente é transformado em um array
    
//     if(resposta == true) 
//     {
//         console.log("Usuário Criado: ", resposta);
//     };
    
// }

const url = "http://localhost:5290/api/Pessoas";

// POST
const botaoEnvio = document.querySelector("#botaoEnvio");

if (botaoEnvio) {
    botaoEnvio.onclick = async function (event) {
        event.preventDefault();

        const nome = document.querySelector("#nomeEnvio").value;
        const email = document.querySelector("#emailEnvio").value;

        try {
            const resposta = await fetch(url, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ nome, email })
            });

            if (resposta.ok) {
                console.log("Usuário criado");
            } else {
                console.log("Erro:", await resposta.text());
            }
        } catch (erro) {
            console.error("Falha na requisição:", erro);
        }
    };
}

// GET
const botaoBuscaUsuarios = document.querySelector("#botaoBuscaUsuarios");
const listaUsuarios = document.querySelector("#listaUsuarios");

if (botaoBuscaUsuarios) {
    botaoBuscaUsuarios.onclick = async function (event) {
        event.preventDefault();

        try {
            const resposta = await fetch(url);

            if (!resposta.ok) {
                console.error("Erro na API:", resposta.status);
                return;
            }

            const usuarios = await resposta.json();
            console.log("recebido da API:", usuarios);

            listaUsuarios.innerHTML = "";

            if (usuarios.length === 0) {
                listaUsuarios.innerHTML = "<li>Nenhum usuário cadastrado</li>";
                return;
            }

            usuarios.forEach(usuario => {
                const item = document.createElement("li");
                item.textContent = `${usuario.nome} - ${usuario.email}`;
                listaUsuarios.appendChild(item);
            });
        } catch (erro) {
            console.error("Falha na requisição:", erro);
        }
    };
}