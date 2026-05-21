// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {

    const mainImage =
        document.getElementById("mainImage");

    const buttons =
        document.querySelectorAll("[data-image]");

    buttons.forEach(button => {

        button.addEventListener("click", function () {

            const image =
                button.getAttribute("data-image");

            if (mainImage && image) {
                mainImage.src = image;
            }

        });

    });

});