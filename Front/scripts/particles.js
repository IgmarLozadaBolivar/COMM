tsParticles.load({
    id: "tsparticles",
    options: {
        preset: "triangles",
        particles: {
            move: {
                speed: 1,
            },
            color: {
                value: "#305da8"
            },
            links: {
                color: "#305da8",
                distance: 100,
                enable: true,
                opacity: 0.5,
                width: 1
            },
        },
        background: {
            color: {
                value: "#d7e2f4"
            },
            image: "", /* Se puede agregar una ft de fondo */
            position: "50% 50%",
            repeat: "no-repeat",
            size: "cover"
        }
    },
});

Swal.fire({
    title: '¡Bienvenido!',
    text: 'Te invito a que valides tu usuario!',
    icon: 'info',
    confirmButtonText: 'Aceptar'
});

const urlAuth = "http://localhost:5033/User/validarUser";
const urlRegister = "http://localhost:5183/User/registrar";
const headers = new Headers({ 'Content-Type': 'application/json' });
const botonLogin = document.getElementById('boton');
const botonRegister = document.getElementById('botonRegistro');

botonLogin.addEventListener("click", function (e) {
    e.preventDefault();
    autorizarUsuario();
});

async function autorizarUsuario() {
    let inputUsuario = document.getElementById('username').value;
    let inputPassword = document.getElementById('password').value;

    let data = {
        "username": inputUsuario,
        "password": inputPassword
    }

    const config = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    };

    try {
        const response = await fetch(urlAuth, config);

        if (response.ok) {
            // La autenticación fue exitosa, redirige al usuario a la página Swagger
            window.location.href = "http://localhost:5033/swagger";
        } else {
            // La autenticación falló, muestra un mensaje de error o redirige al usuario a la página de registro
            alert("Autenticación fallida. Verifique sus credenciales o regístrese.");
        }
    } catch (error) {
        console.error("Error al realizar la autenticación:", error);
    }
}

botonRegister.addEventListener("click", function (e) {
    e.preventDefault();
    registrarUsuario();
});

async function registrarUsuario() {
    let inputUsuario = document.getElementById('username').value;
    let inputPassword = document.getElementById('password').value;

    let data = {
        "username": inputUsuario,
        "password": inputPassword
    }

    const config = {
        method: 'POST',
        headers: headers,
        body: JSON.stringify(data)
    };

    try {
        const response = await fetch(`${urlRegister}`, config);

        if (response.status === 200) {
            window.location.href = './auth.html';
        } else {
            console.error("La solicitud no fue exitosa. Estado:", response.status);
        }
    } catch (error) {
        console.error("Error de red: ", error);
    }
}