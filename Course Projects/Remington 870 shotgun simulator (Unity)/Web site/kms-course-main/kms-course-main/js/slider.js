document.addEventListener("DOMContentLoaded", function () {
  var myCarousel = document.getElementById("carouselExampleControls");
  var carousel = new bootstrap.Carousel(myCarousel, {
    interval: 3000, // Интервал в миллисекундах между автоматической прокруткой слайдов
  });

  // Запускаем автоматическую прокрутку слайдера
  setTimeout(function () {
    carousel.cycle();
  }, 1000); // Задержка в миллисекундах перед запуском автоматической прокрутки (в данном случае 1 секунда)
});
