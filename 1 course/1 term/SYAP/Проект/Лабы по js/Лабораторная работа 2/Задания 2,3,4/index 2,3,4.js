function fun1() {
    let a;
    a=prompt("Введите a");
    let b;
    b=prompt("Введите b");
    document.write("<table cellspacing='0' border='2' cellpadding='5' align='center' style='background: rgba(0, 128, 128, 0.651)'>");
    for(let i=1;i<=a;i++) {
    document.write("<tr>");
    for(let u=1;u<=b;u++) {
        document.write("<td>" + i*u + "</td>");
    }
 document.write("</tr>"); /* document - объект, .write - метод объекта */
 } 
 document.write("</table>");
}
function fun2() {
    let Radius1;
    Radius1=prompt("Введите a");
    Radius1=parseInt(Radius1, 10);
    let Radius2;
    Radius2=prompt("Введите b");
    Radius2=parseInt(Radius2, 10);
    document.write("<table border='2' cellspacing='0' cellpadding='5' align='center' style='background: rgba(0, 128, 128, 0.651)'>");
    document.write("<tr>");
    document.write("<td>" + "Радиус" + "</td>");
    document.write("<td>" + "Площадь круга" + "</td>");
    document.write("<td>" + "Длина окружности" + "</td>");
    document.write("</tr>");
    do {
    document.write("<tr>");
    document.write("<td>" + Radius1.toFixed(1) + "</td>");// метод toFixed - представляет число в форме с фиксированным количеством цифр после точки
    document.write("<td>" + Math.round(Math.PI*Math.pow(Radius1, 2)) + "</td>");// .PI - одно из свойств объекта Math
    document.write("<td>" + Math.round(2*Math.PI*Radius1) + "</td>");
    document.write("</tr>");
    Radius1=Radius1+0.3;
    }
    while (Radius1<Radius2);
    
    document.write("<tr>");
    document.write("<td>" + Radius2 + "</td>");
    document.write("<td>" + Math.round(Math.PI*Math.pow(Radius2, 2)) + "</td>");
    document.write("<td>" + Math.round(2*Math.PI*Radius2) + "</td>");
    document.write("</tr>");
  document.write("</table>");
}
function fun3() {
  let x;
    x=prompt("Введите первое число");
    let numb1 = new Number(x);
  let y;
    y=prompt("Введите второе число");
    let numb2 = new Number(y);
      document.write("<table cellspacing='0' border='2' cellpadding='5' align='center' style='background: rgba(0, 128, 128, 0.651)'>");

      document.write("<tr>");
      document.write("<th>" + "Число" + "</th>");
      document.write("<th>" + "Название метода" + "</th>");
      document.write("<th>" + "Результат" + "</th>");
      document.write("<th>" + "Описание метода" + "</th>");

      document.write("<tr>");
      document.write("<td>" + numb1 + "</td>");
      document.write("<td rowspan='2'>" + "toExponential(количество)" + "</td>");
      document.write("<td>" + numb1.toExponential(2) + "</td>");
      document.write("<td rowspan='2'>" + "Представляет число в экспоненциальной форме. Параметр количество – целое число, определяющее, сколько цифр после точки следует указывать");

      document.write("<tr>");
      document.write("<td>" + numb2 + "</td>");
      document.write("<td>" + numb2.toExponential(2) + "</td>");
      document.write("</tr>");

      document.write("<tr>");
      document.write("<td>" + numb1 + "</td>");
      document.write("<td rowspan='2'>" + "toFixed(количество)" + "</td>");
      document.write("<td>" + numb1.toFixed(3) + "</td>");
      document.write("<td rowspan='2'>" + "Представляет число в форме с фиксированным количеством цифр после точки. Параметр количество – целое число, определяющее сколько цифр после точки следует указывать.");

      document.write("<tr>");
      document.write("<td>" + numb2 + "</td>");
      document.write("<td>" + numb2.toFixed(3) + "</td>");
      document.write("</tr>");

      document.write("<tr>");
      document.write("<td>" + numb1 + "</td>");
      document.write("<td rowspan='2'>" + "toPrecision(точность)" + "</td>");
      document.write("<td>" + numb1.toPrecision(1) + "</td>");
      document.write("<td rowspan='2'>" + "Представляет число с заданным общим количеством значащих цифр. Параметр точность – целое число, определяющее, сколько всего цифр, до и после точки, следует указывать.");

      document.write("<tr>");
      document.write("<td>" + numb2 + "</td>");
      document.write("<td>" + numb2.toPrecision(1) + "</td>");
      document.write("</tr>");

      document.write("<tr>");
      document.write("<td>" + numb1 + "</td>");
      document.write("<td rowspan='2'>" + "toString(основание)" + "</td>");
      document.write("<td>" + numb1.toString(16) + "</td>"); //возвращает строковое представление числа в системе счисления с указанным основанием
      document.write("<td rowspan='2'>" + "Возвращает строковое представление числа в системе счисления с указанным основанием. Если параметр не указан, имеется в виду десятеричная система счисления. Этот метод имеют все объекты." + "</td>");

      document.write("<tr>");
      document.write("<td>" + numb2 + "</td>");
      document.write("<td>" + numb2.toString(16) + "</td>");
      document.write("<tr>");

      document.write("</table>");
}