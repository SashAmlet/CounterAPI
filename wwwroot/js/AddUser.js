const uri = 'api/Users';
let users = [];

function getUsers() {
    // JS функція, за допомогою якої можна подати запит на сторінку "uri"
    fetch(uri) // по замовченю викликаю метод GET без параметрів, тож на виході отримую набір юзерів
        .then(response => response.json()) // перетворюю дані в об'єкт JS
        .then(data => _displayUsers(data)) // відправляю той об'єк в функцію _displayUsers
        .catch(error => console.error('Unable to get users.', error));
}

function addUser() {
    // дістаю відповідні елементи з Index.html, в яких я пишу нову інфу
    const addNameTextbox = document.getElementById('add-name');
    const addThemeTextbox = document.getElementById('add-theme');
    const addLanguageTextbox = document.getElementById('add-language');
    const addNotificationRadiobox = document.getElementById('add-notification');
    var _notifications = false;
    if (addNotificationRadiobox.checked)
        _notifications = true;
    // формую нового user як JS об'єкт покладаючись на отриману інфу
    const user = {
        id: 0,
        name: addNameTextbox.value.trim(),
        personalizationId: 0,
        templateLists: null,
        personalization: {
            id: 0,
            notifications: _notifications,
            theme: addThemeTextbox.value.trim(),
            language: addLanguageTextbox.value.trim()
        }
    };
    // перевірка. виводжу отриманого user в консоль
    console.info(JSON.stringify(user));
    // найвеселіше - відправляю HTTP запит до uri
    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(response => response.json())
        .then(() => {
            getUsers();
            addNameTextbox.value = '';
            addThemeTextbox.value = '';
            addLanguageTextbox.value = '';
            _notifications = false;
        })
        .catch(error => console.error('Unable to add user.', error));
}

function deleteUser(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getUsers())
        .catch(error => console.error('Unable to delete user.', error));
}

function displayEditForm(id) {
    const user = users.find(user => user.id === id);

    document.getElementById('edit-id').value = user.id;
    document.getElementById('edit-name').value = user.name;
    document.getElementById('edit-notification').value = user.notifications;
    document.getElementById('edit-theme').value = user.theme;
    document.getElementById('edit-language').value = user.language;
    document.getElementById('editForm').style.display = 'block';
}

function updateUser() {
    const userId = document.getElementById('edit-id').value;
    const user = {
        id: parseInt(userId, 10),
        name: document.getElementById('edit-name').value.trim(),
        info: document.getElementById('edit-desctiption').value.trim()
    };

    fetch(`${uri}/${userId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    })
        .then(() => getUser())
        .catch(error => console.error('Unable to update user.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayUsers(data) {
    const tBody = document.getElementById('users'); // знаходжу місце, куди вставляти інфу по юзерам
    tBody.innerHTML = '';


    const button = document.createElement('button');

    // для кожного юзера з набору data виводжу відповідну інформацію та додаю кнопочки
    data.forEach(user => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${user.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteCategory(${user.id})`);

        // створюю імпровізовану табличку, де з кожним юзером створюю наві рядки
        let tr = tBody.insertRow();

        // для кожної властивості створюю нову колонку (клітину в рядочку)
        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(user.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeNotif = document.createTextNode(user.personalization.notifications);
        td2.appendChild(textNodeNotif);

        let td3 = tr.insertCell(2);
        let textNodeTheme = document.createTextNode(user.personalization.theme);
        td3.appendChild(textNodeTheme);

        let td4 = tr.insertCell(3);
        let textNodeLanguage = document.createTextNode(user.personalization.language);
        td4.appendChild(textNodeLanguage);

        let td5 = tr.insertCell(4);
        td5.appendChild(editButton);

        let td6 = tr.insertCell(5);
        td6.appendChild(deleteButton);
    });

    users = data; 
}
