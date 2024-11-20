// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener("DOMContentLoaded", function () {
    const menuItems = document.querySelectorAll('.wrapper .sidebar ul li');

    menuItems.forEach(item => {
        item.addEventListener('click', function () {
            // Remove "active" class from all items
            menuItems.forEach(i => i.classList.remove('active'));

            // Add "active" class to the clicked item
            this.classList.add('active');
        });
    });
});