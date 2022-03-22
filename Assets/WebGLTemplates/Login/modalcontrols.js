//MODALS
const modal_container = document.getElementById('modal_container');
const closeButton = document.getElementById('close');
const uploadButton = document.getElementById('upload');


closeButton.addEventListener('click', () => {
    modal_container.classList.remove('show');
});


