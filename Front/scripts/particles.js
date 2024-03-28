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
            image: "",
            position: "50% 50%",
            repeat: "no-repeat",
            size: "cover"
        }
    },
});