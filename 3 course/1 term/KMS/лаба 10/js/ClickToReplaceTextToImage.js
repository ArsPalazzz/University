document.addEventListener("DOMContentLoaded", function () {
  const replacements = document.querySelectorAll(".replacement");

  replacements.forEach((replacement, index) => {
    replacement.addEventListener("click", function () {
      replacement.style.display = "none";
      let nextImg = replacements[index + 1];

      if (nextImg) {
        nextImg.style.display = "block";
      }
    });

    replacement.addEventListener("mouseleave", function () {
      replacement.style.display = "inline";
      let nextImg = replacements[index + 1];

      if (nextImg) {
        nextImg.style.display = "none";
      }
    });
  });
});
