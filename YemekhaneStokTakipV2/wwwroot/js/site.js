document.addEventListener("DOMContentLoaded", function () {

    // Kart Animasyonu
    const cards = document.querySelectorAll(".card");

    cards.forEach((card, index) => {

        card.style.opacity = "0";
        card.style.transform = "translateY(25px)";

        setTimeout(() => {

            card.style.transition = "all .5s ease";
            card.style.opacity = "1";
            card.style.transform = "translateY(0)";

        }, index * 120);

    });

    // Sayaç Animasyonu
    const numbers = document.querySelectorAll("h2");

    numbers.forEach(number => {

        const target = parseInt(number.innerText);

        if (isNaN(target))
            return;

        let count = 0;

        const speed = Math.max(1, Math.ceil(target / 50));

        const timer = setInterval(() => {

            count += speed;

            if (count >= target) {

                number.innerText = target;

                clearInterval(timer);

            }
            else {

                number.innerText = count;

            }

        }, 20);

    });

});