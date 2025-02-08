function fun1() {
    alert("Вас приветствует учебный центр");
}
function fun2() {
    let x; //переменная это хранилище для данных
    x=prompt("Введите имя");
    alert("Здравствуйте, " + x);
}
function fun3() {
    
    if (confirm("Хотите стать web-дизайнером?")) {
    alert("Учите стили CSS и JavaScript!");
    }
    else {
    alert("Упускаете время!");
    }
}
function fun4() {
    alert(10+5);
}
function fun5() {
    alert("10"+"5");
}
function fun6() {
    alert(22+"5");
}
function fun7() {
    alert("22"+5);
}
function fun8() {
    alert("Результатом сложения строки и числа всегда будет строка");
}
function fun9() {
    let x=5;
    let y=8;
    let x0 = ((15*x)/(3*y)*20);
    let y0 = ((7*x)/(15*y)*3);
    let z0 = x0%y0;
    alert("Результат первого выражения:" +x0 +";" +"Результат второго выражения:" +y0 +";" +"Остаток от деления первого выражения на второе:" +z0);
    document.write(x0 + ";" + y0 + ";" + z0);
}
function fun10() {
    let x;
    x=prompt("Введите любое число")
    if 
    (x==null) {
    alert("Вы не ввели число");}
    else {
   if ((x>40|| x<20) && x!=60 && x%5==0) {
       alert("Правильное значение"); }
    else {
        alert("Неправильное значение")
       }
     }
   }
function fun11() {
    let x;
    let y;
    x=prompt("Введите первое число");
    y=prompt("Введите второе число");
    if (x>y) {
        alert("Первое число больше второго"); }
    else {
     if (x<y) {
         alert("Первое число меньше второго"); }
     else {
         alert("Числа равны");
     }
  }   
}
function fun12() {
    let x1;
    x1=prompt("Сколько кеглей сбил игрок 1 в первом раунде?", "8");
    x1=parseInt(x1, 10);
    let y1;
    y1=prompt("Сколько кеглей сбил игрок 2 в первом раунде?", "5");
    y1=parseInt(y1, 10);
    let x2;
    x2=prompt("Сколько кеглей сбил игрок 1 во втором раунде?", "7");
    x2=parseInt(x2, 10);
    let y2;
    y2=prompt("Сколько кеглей сбил игрок 2 во втором раунде?", "3");
    y2=parseInt(y2, 10);
    let x3;
    x3=prompt("Сколько кеглей сбил игрок 1 в третьем раунде?", "9");
    x3=parseInt(x3, 10);
    let y3;
    y3=prompt("Сколько кеглей сбил игрок 2 в третьем раунде?", "6");
    y3=parseInt(y3, 10);
    let x0;
    x0=x1+x2+x3;
    let y0;
    y0=y1+y2+y3;
    if (x0>y0) {
        alert("Игрок 1 победил со счетом-" + x0 + ":" + y0);}
    else {
        if(x0<y0) {
            alert("Игрок 2 победил со счетом-" + y0 + ":" + x0);}
        else {
            alert("Ничья; У обеих команд по " + x0 + " очков");
        }
    } 
}
function fun13() {
    let x1;
    x1=prompt("Сколько кеглей сбил игрок 1 в первом раунде?", "8");
    x1=parseInt(x1, 10);
    let y1;
    y1=prompt("Сколько кеглей сбил игрок 2 в первом раунде?", "5");
    y1=parseInt(y1, 10);
    let x2;
    x2=prompt("Сколько кеглей сбил игрок 1 во втором раунде?", "7");
    x2=parseInt(x2, 10);
    let y2;
    y2=prompt("Сколько кеглей сбил игрок 2 во втором раунде?", "3");
    y2=parseInt(y2, 10);
    let x3;
    x3=prompt("Сколько кеглей сбил игрок 1 в третьем раунде?", "9");
    x3=parseInt(x3, 10);
    let y3;
    y3=prompt("Сколько кеглей сбил игрок 2 в третьем раунде?", "6");
    y3=parseInt(y3, 10);
    let x0;
    x0=x1+x2+x3;
    let y0;
    y0=y1+y2+y3;
    let z1=(x0>y0)?("Игрок 1 победил со счетом-" + x0 + ":" + y0):("Игрок 2 победил со счетом-" + y0 + ":" + x0);
    alert(z1)
}
function fun14() {
    let x;
    x=prompt("Введите число от 1 до 7");
    switch(x) {
        case"1":
        alert("Сегодня понедельник");
        break;
        case"2":
        alert("Сегодня вторник");
        break;
        case"3":
        alert("Сегодня среда");
        break;
        case"4":
        alert("Сегодня четверг");
        break;
        case"5":
        alert("Сегодня пятница");
        break;
        case"6":
        alert("Сегодня суббота");
        break;
        case"7":
        alert("Сегодня воскресенье");
        break;
        default:
        alert("Число не входит в промежуток");
        break;
    }

}
function fun15() {
    try {
        alert("Поиск ошибки");
        qqqqq
        alert("Ошибки не найдено"); }
    catch(err) {
        alert("Ошибка найдена");
    }    
}