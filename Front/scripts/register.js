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

const botonRegister = document.getElementById('botonRegistro');
const urlRegister = "http://localhost:5033/Api/User/register";
const headers = new Headers({ 'Content-Type': 'application/json' });

botonRegister.addEventListener("click", function (e) {
    e.preventDefault();
    registrarUsuario();
});

async function registrarUsuario() {
    let inputUsuario = document.getElementById('username').value;
    let inputPassword = document.getElementById('password').value;

    let data = {
        "nombre": inputUsuario,
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