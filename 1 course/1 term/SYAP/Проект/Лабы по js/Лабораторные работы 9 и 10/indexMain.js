//1.перетащить мышью область текста и картинку. 
let myimg = document.getElementById('myimg'); 
myimg.onmousedown = function(ev) {
     moveImg(ev)
    function moveImg(ev){
    myimg.style.left = ev.clientX - myimg.offsetWidth/2 + 'px';/*cв-во clientX расст от левой границы экрана до курсора без учета прокрутки
                                                                .offsetWidth- ширина блока/2 т.е курсор будет в центре нашего блока*/    
    myimg.style.top = ev.clientY - myimg.offsetHeight/2 + 'px';/*clientY расстояние от верхней границы экрана до курсора без учета прокрутки. offsetHeigh высота*/
  }
  document.onmousemove = function(ev){    //mousemove Каждое движение мыши над элементом генерирует это событие.
    moveImg(ev);
  }     
  myimg.onmouseup = function(){         /*mousedown/mouseup*/
    document.onmousemove = null;   /* Кнопка мыши нажата/отпущена над элементом. */
    myimg.onmouseup = null;
  }
}
  // myimg.ondragstart = function(){ //событие ondragstart позволяет задать срабатывание скрипта, когда пользователь начинает перетаскивать элемент.
  //   return false;
  // }

//текст
let mytextarea = document.getElementById('mytext'); 
mytextarea.onmousedown = function(ev){ 
  // moveP(ev)
    function moveP(ev){
      mytextarea.style.left = ev.clientX  - mytextarea.offsetWidth/2 + 'px';
      mytextarea.style.top = ev.clientY - mytextarea.offsetHeight/2 + 'px';
    }
    document.onmousemove = function(ev){
    moveP(ev);
    }
    mytextarea.onmouseup = function(){
      document.onmousemove = null;
      mytextarea.onmouseup = null;
    }
}
// mytextarea.ondragstart = function(){
// return false;
// }

//2. Создать программу на JS, организующую движение картинки по прямой линии. 
let idmove;
function init_move(xid, dx, dy){// собираем строку которую потом передадим в нашу функцию движения//в ней двигается
    let prmstr = "'"+xid+"'"+","+dx+","+dy;  
    prmstr = "move(" +prmstr+ ")";//включаем вызов функции move с теми парамметрами которые перешли в init_move
    idmove= setInterval (prmstr , 30);//храним интервал выполн ф-ии move: 30мсек
    //выполняет код много раз, через равные промежутки времени, пока не будет остановлен при помощи clearInterval.
}
  function move(xid, dx , dy) {
    let anim1 = document.getElementById('animimg1'); 
    let x = window.getComputedStyle(anim1,null).getPropertyValue('left').match(/\d+/); //match(/\d+/) - шаблон - взять только цифры типо без px
   // let y = window.getComputedStyle(anim1,null).getPropertyValue('top').match(/\d+/); //шаблоны используются для нахождения прямого соответствия 
//Метод Window.getComputedStyle() возвращает объект, содержащий значения всех CSS-свойств элемента
//getPropertyValue() - метод, который возвращает DOMString указанного CSS свойства
    x=Number(x)+dx; //вправо двигается
    //y=Number(y)+dy;//вниз    ТК В УСЛОВИИ ДВИЖЕНИЕ В БОК ТО "Y" НЕ ИСПОЛЬЗУЕМ
    //anim1.style.top = y+'px';
    anim1.style.left = x+'px';

  if (x > 300) clearInterval(idmove); //остановим дальнейшее выполнение функции
}

init_move('animimg1', 5, 1); 
//параметры какие мы передали в эту функции
//Метод Window.getComputedStyle() возвращает объект, содержащий значения всех CSS-свойств элемента
//getPropertyValue() - метод, который возвращает DOMString указанного CSS свойства
//match(/\d+/) - шаблон - взять только цифры типо без px
//шаблоны используются для нахождения прямого соответствия 


//Создать программу на JS, организующую движение картинки по кривой линии и возврат ее в исходное состояние. 
let animimg2=document.getElementById("animimg2");

animimg2.onclick= function fun(){         
  let start = Date.now(); //вернём колличество милисекунд и вызовем фун регулярно

  let timer = setInterval(function() { //Задать интервал 
      let timePassed = Date.now() - start; //получаем время которое прошло с момента запуска программы
     
      if (timePassed >= 1000){
          drawt(10,600)///////
          clearInterval(timer); // закончить анимацию
          return;
      }
  
      draw(timePassed);
      
  }, 40);//функция отрисовывает //чем больще число тем волна более павольная

  function draw(timePassed){//изменяет положение элемента
  
    animimg2.style.left = timePassed/2 + 'px'
    animimg2.style.top = Math.sin(timePassed)*75 + 600 + 'px';//70-это на сколько она опускается,570-высота располoжения изначально
  }

  function drawt(x, y) {
		animimg2.style.left = x + 'px';


		animimg2.style.top = y + 'px';
	}
} 
//
  let cw = canvas.width;
  let ch = canvas.height;
  let ctx = document.getElementById('canvas').getContext('2d'); //измерение
  let dlin = 40; 
  function graf() {
        for (x = -cw / 1 / dlin; x < cw / 1 / dlin; x += 1 / dlin) {
            eval(document.forms['mygrafic'].elements['funcz'].value);
            ctx.fillRect(x * dlin + cw / 5, ch - (y * dlin + ch / 5), 5, 3);//fillRect(x, y, width, height) Рисование заполненного прямоугольника.
            ctx.fillStyle = document.getElementById('funccolor').value;//fill() Рисует фигуру с заливкой внутренней области.
        }
    }
  function clearcanvas(){
      let canvas = document.getElementById('canvas'),
      ctx = canvas.getContext("2d");
      ctx.clearRect(0, 0, canvas.width, canvas.height); //clearRect - очистка области
    }

//меню

    document.getElementById('nav').onmouseover = function(event){//отслеживает нахождение мыши внутри блока
      let target = event.target;
//отслеживаем клик
      if (target.className == 'menu-item'){
        let sbmen = target.getElementsByClassName('submenu');
      closeMenu();
      sbmen[0].style.display='block';
//массив, содержащий ложное меню
      }
  }


  document.onmouseover=function(event){
    let target = event.target;
      console.log(event.target);//Console.log () это ф-ия в JS, котор использ для печати любых переменных, определенных ранее, или для печати любого сообщения, которое необходимо отобразить пользователю.
      if (target.className!='menu-item' && target.className!='submenu'){
          closeMenu();
      }
  }

 function closeMenu(){
//получение всех элементов подменю в блоке nav, присваивание  display:none
let menu = document.getElementById('nav');
let subm=document.getElementsByClassName('submenu');
  for (let i=0; i <subm.length; i++){
      subm[i].style.display ="none";
  }
}

/*Чтобы начать рисовать на холсте, нужно получить контекст рисования методом
getContext(), который принимает имя контекста. Например, передав ему значение
"2d", можно получить объект двухмерного контекста */