function fun1() {//ЗНАТЬ ПРОТОТИПЫ(КОГДА РАБОТАЕМ С КОНСТРУКТОРАМИ) И МАССИВЫ
    let arr1 = [6*Math.pow(Math.PI, 2) + 3*Math.exp(8), 2*Math.cos(4) + Math.cos(12) + 8*Math.exp(3), 3*Math.sin(9) + Math.log(5) + Math.sqrt(3), 2*Math.tan(5) + 6*Math.PI + Math.sqrt(12)];
    let min = arr1[0]; //связываем переменные min и max с массивом arr1
    let max = arr1[0];
    let k=0, n=0;
        for (let i = 0; i < arr1.length; i++) {
              if (arr1[i] > max)
                 max = arr1[i], k=i;
              if (arr1[i] < min)
                 min = arr1[i], n=i;
        }
        alert("Исходный массив: " + arr1 + "." + "\nМаксимальный элемент массива: " + max + ", его номер " + k + ". " + "\nМинимальный элемент массива: " + min + ", его номер " + n + ".");
}

function fun2() {
    let arr2 = ["pow", "pop", "push", "shift", "round", "floor", "sline", "sort"];
    let arrMethods1 = arr2.slice(1,4);//pop, push, shift
    let arrMethods2 = arr2.slice(6,8);//sline, sort
    let arrayMethods = arrMethods1.concat(arrMethods2);

    let mathMethods1 = arr2.slice(0,1);//pow
    let mathMethods2 = arr2.slice(4,6);//round, floor
    let mathMethods = mathMethods1.concat(mathMethods2);

    arrayMethods.unshift("concat");
    mathMethods.push("log");

    alert("Исходный массив: " + arr2 + "\nМассив метода объекта Array: " + arrayMethods + "\nЕго длина: " + arrayMethods.length + " элементов" + "\nМассив метода объекта Math: " + mathMethods + "\nЕго длина: " + mathMethods.length + " элемента");   
}

function fun3() {
    let fullName = new String("Палазник Арсений Викторович");
    let fullNameBig = fullName.toUpperCase();
    let fullNameSmall = fullName.toLowerCase();
    let fullNameConn = fullNameBig.concat(fullNameSmall);
    let fio = fullName.replace("Палазник Арсений Викторович", "ПАВ");

    alert("Полное имя: " + fullName + "\nДлина строки: " + fullName.length + " символов" + "\nВерхний регистр: " + fullNameBig + "\nНижний регистр: " + fullNameSmall + "\nСовмещение строк: " + fullNameConn + "\nФИО: " + fio); //.length - свойство объекта
}

function fun4() {
    let date = new Date();//создание объекта Date
    let year = date.getFullYear(); // методы, которые возвращают год, месяц, день недели, час, минуты и секунды
    let month = date.getMonth();
    let day = date.getDay();
    let hour = date.getHours();
    let minutes = date.getMinutes();
    let seconds = date.getSeconds();

    document.write("<table border='2' cellspacing='0' cellpadding='3' align='center'"); //cellpadding - расст. между границей ячейки и ее содержимым
      document.write("<tr>" + "<td>" + "Год" + "</td>" + "<td>" + year + "</td>");
      document.write("<tr>" + "<td>" + "Месяц" + "</td>" + "<td>" + month + "</td>");
      document.write("<tr>" + "<td>" + "День" + "</td>" + "<td>" + day + "</td>");
      document.write("<tr>" + "<td>" + "Час" + "</td>" + "<td>" + hour + "</td>");
      document.write("<tr>" + "<td>" + "Минуты" + "</td>" + "<td>" + minutes + "</td>");
      document.write("<tr>" + "<td>" + "Секунды" + "</td>" + "<td>" + seconds + "</td>");
}