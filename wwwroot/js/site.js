// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const listItems = document.querySelectorAll('.wrapper .sidebar ul li');

// Add click event listener to each item
listItems.forEach(item => {
    item.addEventListener('click', function () {
        // Remove 'active' class from all items
        listItems.forEach(li => li.classList.remove('active'));

        // Add 'active' class to the clicked item
        this.classList.add('active');
    });
});

function setActive(element) {
    // Remove "active" class from all list items
    const items = document.querySelectorAll('.wrapper .sidebar ul li');
    items.forEach(item => item.classList.remove('active'));

    // Add "active" class to the clicked item
    element.classList.add('active');
}

function setActive(element) {
    // Remove "active" class from all list items
    const items = document.querySelectorAll('.wrapper .sidebar ul li');
    items.forEach(item => item.classList.remove('active'));

    // Add "active" class to the clicked item
    element.classList.add('active');
}