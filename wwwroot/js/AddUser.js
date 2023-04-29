const usersUri = 'api/Users';
let users = [];

function getUsers() {
    // JS функція, за допомогою якої можна подати запит на сторінку "uri"
    fetch(usersUri) // по замовченю викликаю метод GET без параметрів, тож на виході отримую набір юзерів
        .then(response => response.json()) // перетворюю дані в об'єкт JS
        .then(data => _displayUsers(data)) // відправляю той об'єк в функцію _displayUsers
        .catch(error => console.error('Unable to get users.', error));
}

async function getLanguageId(languageData) {
    const languageIndexUrl = `api/LanguageLists/${languageData}`;
    try {
        const response = await fetch(languageIndexUrl);
        if (response.ok) {
            const data = await response.json();
            return data;
        }
        throw new Error('Failed to fetch data');
    } catch (error) {
        console.error('Unable to get language data.', error);
        throw error;
    }
}

async function getThemeId(themeData) {
    const themeIndexUrl = `api/ThemeLists/${themeData}`;
    try {
        const response = await fetch(themeIndexUrl);
        if (response.ok) {
            const data = await response.json();
            return data;
        }
        throw new Error('Failed to fetch data');
    } catch (error) {
        console.error('Unable to get theme data.', error);
        throw error;
    }
}

function getUserData() {
    // дістаю відповідні елементи з Index.html, в яких я пишу нову інфу
    const addNameTextbox = document.getElementById('user-input-name');
    const addThemeTextbox = document.getElementById('user-select-theme');
    const addLanguageTextbox = document.getElementById('user-select-language');
    const addNotificationRadiobox = document.getElementById('user-input-notification');
    var _notifications = false;

    if (addNotificationRadiobox.checked)
        _notifications = true;
    // дістаю індекс вибраної мови
    getLanguageId(addLanguageTextbox.value).then(ldata => {
        getThemeId(addThemeTextbox.value).then(tdata => {
            addUser(addNameTextbox.value.trim(), _notifications, ldata, tdata)
        }).catch(error => { error => console.error('Unable to get themeId.', error) });

    }).catch(error => { error => console.error('Unable to get languageId.', error) });
}

function addUser(_name, _notifications, language, theme) {
    // формую нового user як JS об'єкт покладаючись на отриману інфу
    const user = {
        id: 0,
        name: _name,
        personalizationId: 0,
        templateLists: null,
        personalization: {
            id: 0,
            notifications: _notifications,
            languageId: language,
            language: null,
            themeId: theme,
            theme: null,
            userId: 0,
            user: null
        }
    };
    // перевірка. виводжу отриманого user в консоль

    console.info(JSON.stringify(user));
    // найвеселіше - відправляю HTTP запит до uri (так як нам потрібно POST, то вказуємо допоміжні параметри)
    fetch(usersUri, {
        method: 'POST', // вказуємо метод
        headers: {
            'Accept': 'application/json', // так як дані можна отримувати в різних форматах, то вказуємо, що запрошені дані повинні бути у форматі json
            'Content-Type': 'application/json' // так як дані можна відправляти в різних форматах, то вказуємо, що ми відправляємо саме json, щоб сервер правильно все опрацював
        },
        body: JSON.stringify(user) // відправляємо на сервер JS об'єкт user серіалізований у json 
    })
        .then(() => { // чистимо параметри
            getUsers();
        })
        .catch(error => console.error('Unable to add user.', error));
}

function deleteUser(id) {
    // крім до uri додаю ще id, бо видалити треба конкретного user (див. відповідний метод контроллера)
    fetch(`${usersUri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getUsers()) // після видалення оновлюю таблицю виводу.
        .catch(error => console.error('Unable to delete user.', error));
}

function displayEditForm(id) {
    const user = users.find(user => user.id == id);

    document.getElementById('user-edit-userId').value = user.id;
    document.getElementById('user-edit-name').value = user.name;
    document.getElementById('user-edit-persId').value = user.personalization.id;
    document.getElementById('user-edit-notifications').checked = user.personalization.notifications;
    document.getElementById('user-edit-theme').value = user.personalization.theme.name;
    document.getElementById('user-edit-language').value = user.personalization.language.name;
    document.getElementById('user-edit-div').style.display = 'block';

    
}

function updateUser() {
    // дістаю дані про user з блоку edit
    const userId = document.getElementById('user-edit-userId').value;
    const persId = document.getElementById('user-edit-persId').value;
    const language = document.getElementById('user-edit-language').value;
    const theme = document.getElementById('user-edit-theme').value;
    var notif = document.getElementById('user-edit-notifications').checked;

    getLanguageId(language).then(ldata => {
        getThemeId(theme).then(tdata => {
            const user = {
                id: parseInt(userId, 10),
                name: document.getElementById('user-edit-name').value.trim(),
                personalizationId: parseInt(persId, 10),
                templateLists: null,
                personalization: {
                    id: parseInt(persId, 10),
                    themeId: parseInt(tdata, 10),
                    theme: null,
                    languageId: parseInt(ldata, 10),
                    language: null,
                    notifications: notif,
                }
            };
            console.info(JSON.stringify(user));
            // відпаравляю HTTP запит з параметром PUT щоб змінити відповідного user
            fetch(`${usersUri}/${userId}`, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(user)
            })
                .then(() => getUsers()) // оноклюю таблицю з users 
                .catch(error => console.error('Unable to update user.', error));

            closeInput();

            return false;

        }).catch(error => { error => console.error('Unable to get themeId.', error) });

    }).catch(error => { error => console.error('Unable to get languageId.', error) });

    
}

function closeInput() {
    document.getElementById('user-edit-div').style.display = 'none';
}

function _displayUsers(data) {

    const tBody = document.getElementById('user-show-table-users'); // знаходжу місце, куди вставляти інфу по юзерам
    tBody.innerHTML = '';


    const button = document.createElement('button');

    // для кожного юзера з набору data виводжу відповідну інформацію та додаю кнопочки
    if (Array.isArray(data)) {
        data.forEach(user => {
            let editButton = button.cloneNode(false);
            editButton.innerText = 'Edit';
            editButton.setAttribute('onclick', `displayEditForm(${user.id})`);

            let deleteButton = button.cloneNode(false);
            deleteButton.innerText = 'Delete';
            deleteButton.setAttribute('onclick', `deleteUser(${user.id})`);

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
            let textNodeLanguage = document.createTextNode(user.personalization.language.name);
            td3.appendChild(textNodeLanguage);

            let td4 = tr.insertCell(3);
            let textNodeTheme = document.createTextNode(user.personalization.theme.name);
            td4.appendChild(textNodeTheme);

            let td5 = tr.insertCell(4);
            let selectNodeTemplateLists = document.createElement('select');
            user.templateLists.forEach(tl => {
                let option = document.createElement('option');
                option.value = tl.name;
                option.text = tl.name;
                selectNodeTemplateLists.appendChild(option);

            })
            td5.appendChild(selectNodeTemplateLists);

            let td6 = tr.insertCell(5);
            td6.appendChild(editButton);

            let td7 = tr.insertCell(6);
            td7.appendChild(deleteButton);
        });
    }
    users = data; 
    _displayTLAddUserList(data);
}

