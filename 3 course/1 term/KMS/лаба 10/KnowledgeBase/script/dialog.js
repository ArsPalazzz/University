var dialogOn = false;


function dialog_window() {

  document.body.innerHTML +=
    "<div id='dialog' class='dialog' style='margin-left:-40px;'>" +
    "<div class='label' onclick='toggleDialog()'>Задайте вопрос</div>" +
    "<div class='header'>История</div>" +
    "<div class='history' id='history'></div>" +
    "<div class='question'  ><input id='Qdialog' placeholder='Введите вопрос'  onKeyDown='if(event.keyCode==13)ask(&quot;Qdialog&quot;)'/><br>" +
    '<button onclick=\'ask("Qdialog")\'>Ответ</button>';
  '</div>' + '</div>';


  //РАСПОЗНАВАНИЕ РЕЧИ
  //поле с распознаванием речи. Задаем API-ключ

  window.ya.speechkit.settings.apikey = '5c6d6536-b453-4589-9bc7-f16c7a795106';

  // Добавление элемента управления "Поле для голосового ввода".
  var textline = new ya.speechkit.Textline('Qdialog', {
    onInputFinished: function (text) {
      ask('Qdialog');
    },
  });

 
}

// window.onload = function () {
//     dialog_window();
// };




function toggleDialog() {

  if (dialogOn) {
    $('#dialog').animate({ 'margin-left': '-40px' }, 1000, function () { });
    dialogOn = false;
    
  }

  else {
    $('#dialog').animate({ 'margin-left': '-400px' }, 1000, function () { });
    dialogOn = true;
    
  }
}




function ask(questionInput) {
  var question = document.getElementById(questionInput).value.trim();
  //выдвижение диалогового модуля
  $('#dialog').animate({ 'margin-left': '-400px' }, 1000, function () { });
  dialogOn = true;
  
  var newDiv = document.createElement('div');
  newDiv.className = 'question';
  newDiv.innerHTML = question;
  document.getElementById('history').appendChild(newDiv);
  
  newDiv = document.createElement('div');
 
  newDiv.className = 'answer';
  
  newDiv.innerHTML = getAnswer(question);
  
    newDiv.innerHTML +=
    "<audio controls='true' autoplay='true' src='http://tts.voicetech.yandex.net/generate?format=wav&lang=ru-RU&key=4a4d3a13-d206-45fc-b8fb-e5a562c9f587&text=" +
    1 + 
    "'></audio>";
 
  document.getElementById('history').appendChild(newDiv);

  if(newDiv.lastChild.tagName=="AUDIO"){newDiv.lastChild.play();	}
  
  document.getElementById('history').scrollTop =
    document.getElementById('history').scrollHeight;
 
  document.getElementById(questionInput).value = '';
}

