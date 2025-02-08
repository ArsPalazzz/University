document.addEventListener("DOMContentLoaded", function () {
  const images = document.querySelectorAll(".gallery-image");

  images.forEach((image) => {
    image.addEventListener("click", function () {
      this.style.transform = "scale(1.2)";
    });

    image.addEventListener("mouseleave", function () {
      this.style.transform = "scale(1)";
    });
  });
});
