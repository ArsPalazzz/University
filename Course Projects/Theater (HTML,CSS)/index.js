var btn = document.getElementById("theme-button");//кнопка
var link = document.getElementById("theme-link");//css со светлой темой
var changeEl = document.querySelectorAll(".changeEl");
var plFdate = document.getElementById("dateP");
var clocks = document.querySelectorAll(".changeClock");
var changeIs = document.getElementById("changeIs");
var myfooter = document.querySelector(".footerFlex .part1");

btn.addEventListener("click", function () { ChangeTheme(); }); //click - имя события, function() {ChangeTheme();} - ссылка на функция-обработчик

function ChangeTheme()
{
    let lightTheme = "light.css";
    let darkTheme = "dark.css";
    let el = "img/Buttons/el.png";
    let elwhite = "img/Buttons/elwhite.png";
    let srcfclocks1 = "img/Buttons/clocksWhite.svg";
    let srcfclocks2 = "img/Buttons/clocksBlack.svg";
    let srcfRect1 = "img/Buttons/theaterIsWhite.png";
    let srcfRect2 = "img/Buttons/theaterIs.png";


    var currTheme = link.getAttribute("href");
    var theme = "";

    if(currTheme === lightTheme) {
   	    currTheme = darkTheme;
        for (let i = 0; i < changeEl.length; i++) {
            changeEl[i].src = elwhite;
        }

        for (let i = 0; i < clocks.length; i++) {
            clocks[i].src = srcfclocks1;
        }
        changeIs.src = srcfRect1;
        myfooter.style.backgroundColor = "#0E0E0E";
        
   	    theme = "dark";
    }  else {    
   	    currTheme = lightTheme;

        for (let i = 0; i < changeEl.length; i++) {
            changeEl[i].src = el;
        }

        for (let i = 0; i < clocks.length; i++) {
            clocks[i].src = srcfclocks2;
        }
        changeIs.src = srcfRect2;
        myfooter.style.backgroundColor = "#272727";
        
   	    theme = "light";
    }

    link.setAttribute("href", currTheme);

    Save(theme);
}

function Save(theme)
{
    var Request = new XMLHttpRequest();
    Request.open("GET", "./themes.php?theme=" + theme, true); //У вас путь может отличаться
    Request.send();
}

let mydate = new Date();
let myfDay, myfMonth, mysDay, mysMonth;

if (mydate.getDate() < 10) {
    myfDay = `0${mydate.getDate()}`;
}
else {
    myfDay = mydate.getDate();
}

if (mydate.getMonth() + 1 < 10) {
    myfMonth = `0${mydate.getMonth() + 1}`;
}
else {
    myfMonth = mydate.getMonth() + 1;
}

if (mydate.getDate() + 7 < 10) {
    mysDay = `0${mydate.getDate() + 7}`;
}
else {
    mysDay = mydate.getDate() + 7;
}

if (mysDay > myfDay) {
    mysMonth = myfMonth;
}
else {
    mysMonth = myfMonth + 1;
}

plFdate.innerHTML = `${myfDay}.${myfMonth}.${mydate.getFullYear()} - ${mysDay}.${mysMonth}.${mydate.getFullYear()}`;