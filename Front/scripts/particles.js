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

const urlAuth = "http://localhost:5033/Api/User/token";
const headers = new Headers({ 'Content-Type': 'application/json' });
const botonLogin = document.getElementById('botonLogin');

botonLogin.addEventListener("click", function (e) {
    e.preventDefault();
    autorizarUsuario();
});

async function autorizarUsuario() {
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
        const response = await fetch(urlAuth, config);

        if (response.ok) {
            const responseData = await response.json();
            const token = responseData.token;
            localStorage.setItem('token', token);
            window.location.href = "./dashboard.html";
        } else {
            alert("Autenticación fallida. Verifique sus credenciales o regístrese.");
        }
    } catch (error) {
        console.error("Error al realizar la autenticación:", error);
    }
}