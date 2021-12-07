const select2 = document.querySelectorAll(".currency");
const select1 = document.querySelectorAll(".currency1");
const btn = document.getElementById("btn");
const num = document.getElementById("num");
const ans = document.getElementById("ans");

fetch("https://api.frankfurter.app/currencies")
    .then((data) => data.json())
    .then((data) => {
        display(data);
    });



btn.addEventListener("click", () => {
    let currency1 = select1[1].value;
    let currency2 = select2[0].value;;
    let value = num.value;

    if (currency1 != currency2) {
        convert(currency1, currency2, value);
    } else {
        alert("Choose Diffrent Currency");
    }
});

function convert(currency1, currency2, value) {
    const host = "api.frankfurter.app";
    fetch(
        `https://${host}/latest?amount=${value}&from=${currency1}&to=${currency2}`
    )
        .then((val) => val.json())
        .then((val) => {
            console.log(Object.values(val.rates)[0]);
            ans.value = Object.values(val.rates)[0];
        });
}